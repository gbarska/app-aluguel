using System;
using Dominio.Core;
using Dominio.Usuarios;

namespace Dominio.Reservas
{
    public class Reserva : Entity
    {
        public virtual Periodo Periodo { get; }
        public virtual Local Local { get; }
        public virtual Usuario Usuario { get; }

        protected Reserva()
        {
        }

        public Reserva(Local local, Usuario usuario, Periodo periodo)
            : this()
        {
            Local = local;
            Usuario = usuario;
            Periodo = periodo;
        }
    }
   
}
