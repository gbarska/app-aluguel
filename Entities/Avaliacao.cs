using System;
using Dominio.Core;

namespace Dominio.Entities
{
    public class Avaliacao : Entity
    {
        public virtual Usuario Usuario { get; protected set;}
        public Local Local { get; protected set; }
        public decimal Nota { get; protected set; }
        public string Comentario {get; protected set; }

        protected Avaliacao() : base(Guid.NewGuid())
        {
        }
        protected Avaliacao(Usuario usuario, Local local, decimal nota, string comentario): this()
        {
            Usuario = usuario;
            Local = local;
            Nota = nota;
            Comentario = comentario;
        }

        public Avaliacao Criar(Usuario usuario, Local local, decimal nota, string comentario)
        {
            if (usuario == null )
               throw new Exception("Valor inválido para o campo Usuario.");

            if (local == null )
               throw new Exception("Valor inválido para o campo Local.");

            if ( nota <= 0 )
                throw new Exception("Valor inválido para o campo Nota.");

            if (string.IsNullOrEmpty(comentario))
                throw new Exception("Valor inválido para o campo Nota.");
            
            return new Avaliacao( usuario, local, nota, comentario);
        }


       public void Editar(decimal nota, string comentario)
        {

            if ( nota <= 0 )
                throw new Exception("Valor inválido para o campo Nota.");

            if (string.IsNullOrEmpty(comentario))
                throw new Exception("Valor inválido para o campo Nota.");
            
            Nota = nota;
            Comentario = comentario;     
        }

    }
}