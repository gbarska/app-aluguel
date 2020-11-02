using System;
using Dominio.Core;
using System.Linq;

namespace Dominio.Reservas
{
    public class Uf : Entity
    {
        public static readonly Uf DT = new Uf(Guid.NewGuid(), "Default");
        public static readonly Uf SP = new Uf(Guid.NewGuid(), "São Paulo");
        public static readonly Uf RJ = new Uf(Guid.NewGuid(), "Rio de Janeiro");
        public static readonly Uf PE = new Uf(Guid.NewGuid(), "Pernambuco");
        public static readonly Uf PR = new Uf(Guid.NewGuid(), "Paraná");

        public string Nome {get;}
        
        public static readonly Uf[] Estados = { DT, SP, RJ, PE, PR };
        private Uf(Guid id, string nome)
            : base(id)
        {
            Nome = nome;
        }
        public static Uf FromId(Guid id)
        {
            return Estados.SingleOrDefault(x => x.Id == id);
        }
    }
}