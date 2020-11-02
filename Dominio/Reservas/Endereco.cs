using System;

using System.Threading;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Reservas
{
    public class Endereco : ValueObject
    {
        
        public string Logradouro { get; }
        public string Cidade { get; }
        public int Numero { get; }
        public virtual Uf Uf { get; }
        public static readonly Endereco Vazio = new Endereco("", "", 0, Uf.FromId(Guid.Empty));

       private Endereco(string logradouro, string cidade, int numero, Uf uf)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Numero = numero;
            Uf = uf;
        }

        protected Endereco()
        {
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
