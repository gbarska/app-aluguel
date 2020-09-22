using System;
using System.Threading;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Endereco : ValueObject
    {
        public string Logradouro { get; protected set;}
        public string Cidade { get; protected set;}
        public int Numero { get; protected set; }
        public virtual Uf Uf { get; protected set;}

        protected Endereco()
        {
        }
        protected Endereco(string logradouro, string cidade, int numero, Uf uf): this()
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Numero = numero;
            Uf = uf;
        }

        public Endereco Criar(string logradouro, string cidade, int numero, Uf uf)
        {
             if (string.IsNullOrEmpty(logradouro))
                throw new Exception("Valor inválido para o campo Logradouro.");

            if (string.IsNullOrEmpty(cidade))
               throw new Exception("Valor inválido para o campo Cidade.");

            if (numero <= 0 )
               throw new Exception("Valor inválido para o campo Numero.");
            
            if (uf == null )
               throw new Exception("Valor inválido para o campo Uf.");

            return new Endereco(logradouro, cidade, numero, uf);
        }

        public void Editar(string logradouro, string cidade, int numero, Uf uf)
        {
              if (string.IsNullOrEmpty(logradouro))
                throw new Exception("Valor inválido para o campo Logradouro.");

            if (string.IsNullOrEmpty(cidade))
               throw new Exception("Valor inválido para o campo Cidade.");

            if (numero <= 0 )
               throw new Exception("Valor inválido para o campo Numero.");
            
            if (uf == null )
               throw new Exception("Valor inválido para o campo Uf.");

            Logradouro = logradouro;
            Cidade = cidade;
            Numero = numero;
            Uf = uf;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Logradouro;
            yield return Cidade;
            yield return Numero;
            yield return Uf;
        }
    }
}
