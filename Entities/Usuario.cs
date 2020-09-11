using System.Collections.Generic;
using Dominio.Core;
using Dominio.ValueObjects;

namespace Dominio.Entities
{
    public class Usuario : Entity
    {
        public NomeUsuario Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } 
        public List<Local> Locais {get; set;}
    }
}