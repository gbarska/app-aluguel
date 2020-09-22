using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Core;
using Dominio.ValueObjects;

namespace Dominio.Entities
{
    public class Usuario : Entity
    {
        public virtual NomeUsuario Nome { get; protected set;}
        public string Email { get; protected set;}
        private readonly List<Reserva> _reservas = new List<Reserva>();
        public virtual IReadOnlyList<Reserva> Reservas => _reservas.ToList();
        private readonly List<Local> _locais = new List<Local>();
        public virtual IReadOnlyList<Local> Locais => _locais.ToList();
      
      protected Usuario() : base(Guid.NewGuid())
      {
      }
        protected Usuario(NomeUsuario nome, string email): this()
        {
            Nome = nome;
            Email = email;
        }

        public Usuario Criar(NomeUsuario nome, string email) 
        {
            
             if (nome == null)
                throw new Exception("Valor inválido para o campo Nome.");

            if (string.IsNullOrEmpty(email))
               throw new Exception("Valor inválido para o campo Descricao.");

            return new Usuario(nome, email);
        }

        public void Editar(NomeUsuario nome, string email) 
        {
            
             if (nome == null)
                throw new Exception("Valor inválido para o campo Nome.");

            if (string.IsNullOrEmpty(email))
               throw new Exception("Valor inválido para o campo Descricao.");
            
            Nome = nome;
            Email = email;

        }

        public void Reservar(Reserva reserva)
        {
            if (_reservas.Any(x => x == reserva))
                throw new Exception("Essa Reserva já foi realizada.");

            _reservas.Add(reserva);
        }
        
        public void CancelarReserva(Reserva reserva)
        {
             if (!_reservas.Any(x => x == reserva))
                throw new Exception("A Reserva não existe.");

            _reservas.Remove(reserva); 
        }

        
        public void AnunciarLocal(Local local)
        {
            if (_locais.Any(x => x == local))
                throw new Exception("Esse Local já foi adicionado.");

            _locais.Add(local);
        }

        public void CancelarAnuncio(Local local)
        {
            if (!_locais.Any(x => x == local))
                throw new Exception("O Local não existe.");

            _locais.Add(local);
        }

    }
}