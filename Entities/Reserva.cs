using System;
using Dominio.Core;

namespace Dominio.Entities
{
    public class Reserva : Entity
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public Local Local { get; set; }
        public Usuario Usuario { get; set; }
    }
}
