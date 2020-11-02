using System;
using System.Linq;

namespace Dominio.Core
{
    public class Result {
        public bool IsSuccess { get; }
        public string Error { get; }
        public bool IsFailureure  => !IsSuccess;

        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
                throw new  InvalidOperationException();
            if(!isSuccess && error == string.Empty)
                throw new InvalidOperationException();
            
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Failure(string message){
            return new Result(false, message);
        }
        public static Result<T> Failure<T>(string message){
            return new Result<T>(default(T),false, message);
        }
        public static Result Success(){
            return new Result(true, string.Empty);
        }
        public static Result<T> Success<T>(T value){
            return new Result<T>(value, true, string.Empty);
        }

        public static Result Combine(params Result[] results){
            foreach (var result in results)
            {
                if(result.IsFailureure)
                    return result;
            }

            return Success();
        }
    }
    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get{
                if (!IsSuccess)
                    throw new InvalidOperationException();
            return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, string error): base(isSuccess,error){
            _value = value;
        }
    }
}
