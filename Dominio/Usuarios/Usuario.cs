using System;
using System.Collections.Generic;
using Dominio.Core;
using Dominio.Reservas;

namespace Dominio.Usuarios
{
    public class Usuario : Entity
    {
        public virtual NomeUsuario Nome { get; set; }
        public virtual Email Email { get; set; }
        public List<Reserva> Reservas { get; set; } 
        public List<Local> Locais {get; set;}

        protected Usuario()
        {
        }        
        public Usuario(NomeUsuario nome, Email email): base(Guid.NewGuid())
        {
            Nome = nome;
            Email = email;
        }
    }
}