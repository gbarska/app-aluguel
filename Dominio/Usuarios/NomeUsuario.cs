using System.Collections.Generic;
using Dominio.Core;

namespace Dominio.Usuarios
{
    public class NomeUsuario : ValueObject
    {
        public string Nome { get; }
        public string Sobrenome { get; }

        protected NomeUsuario()
        {
        }
        private NomeUsuario(string nome, string sobrenome): this()
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

         public static Result<NomeUsuario> Criar(string nome, string sobrenome)
         {
            if (string.IsNullOrWhiteSpace(nome))
            return Result.Failure<NomeUsuario>("O Nome não pode ser nulo");
            if (string.IsNullOrWhiteSpace(sobrenome))
                return Result.Failure<NomeUsuario>("O Sobrenome não pode ser nulo");
           
           nome = nome.Trim();
           sobrenome = sobrenome.Trim();

            return Result.Success(new NomeUsuario(nome, sobrenome));
         }
         protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome;
            yield return Sobrenome;
        }
    }
}
