using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dominio.Core;

namespace Dominio.Usuarios
{
    public class Email : ValueObject
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Criar(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<Email>("Email não pode ser vazio.");

            email = email.Trim();

            if (email.Length > 200)
                return Result.Failure<Email>("Email deve ter menos que 200 caracteres.");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Failure<Email>("Email invalido.");

            return Result.Success(new Email(email));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}
