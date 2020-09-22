using System;
using Dominio.Core;
using System.Linq;

namespace Dominio.Entities
{
    public class Uf : Entity
    {
        public string Nome { get; protected set; }

        protected Uf() : base(Guid.NewGuid())
        {
        }
        protected Uf(string nome): this()
        {
            Nome = nome;
        }

        public Uf Criar(string nome ) 
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Valor inválido para campo Nome.");
                
            return new Uf(nome);
        }

        public void Editar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Valor inválido para campo Nome.");
           
           Nome = nome;
        }

    }
}