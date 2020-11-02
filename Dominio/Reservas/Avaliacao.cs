using System;
using Dominio.Core;
using Dominio.Usuarios;

namespace Dominio.Reservas
{
    public class Avaliacao : Entity
    {
        public virtual Usuario Usuario { get; set; }
        public virtual Local Local { get; set; }
        public virtual Nota Nota { get; set; }
        public string Comentario {get; set; }
        
        protected Avaliacao()
        {
        }

        public Avaliacao(Usuario usuario, Local local, Nota nota, string comentario)
        {
            Usuario = usuario;
            Local = local;
            Nota = nota;
            Comentario = comentario;
        }

        public Result EditarComentario(Nota nota, string comentario)
        {
            Nota = nota;
            Comentario = comentario;
            
            return Result.Success();
        }
    }
}