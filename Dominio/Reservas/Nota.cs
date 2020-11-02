using System.Collections.Generic;
using System.Text.RegularExpressions;
using Dominio.Core;

namespace Dominio.Usuarios
{
    public class Nota : ValueObject
    {
        public decimal Value { get; }

        private Nota(decimal value)
        {
            Value = value;
        }

        public static Result<Nota> Criar(decimal nota)
        {
            return Result.Success(new Nota(nota));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Nota nota)
        {
            return nota.Value.ToString();
        }
    }
}
