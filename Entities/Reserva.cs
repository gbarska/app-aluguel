using System;
using Dominio.Core;

namespace Dominio.Entities
{
    public class Reserva : Entity
    {
        public DateTime Inicio { get; protected set; }
        public DateTime Fim { get; protected set; }
        public Local Local { get;  protected set; }
        public virtual Usuario Usuario { get; protected set; }

        protected Reserva() : base(Guid.NewGuid())
        {
        }
        protected Reserva(DateTime inicio, DateTime fim, Local local, Usuario usuario): this()
        {
                    Inicio = inicio;
                    Fim = fim;
                    Local = local;
                    Usuario = usuario;
        }

        public Reserva Criar(DateTime inicio, DateTime fim, Local local, Usuario usuario)
        {
           if (usuario == null )
               throw new Exception("Valor inválido para o campo Usuario.");

           if (local == null )
               throw new Exception("Valor inválido para o campo Local.");

           if (fim > inicio )
               throw new Exception("A data da reserva não é valida.");

            return new Reserva(inicio, fim, local, usuario);
        }

        public void Editar(DateTime inicio, DateTime fim, Local local, Usuario usuario)
        {
           if (usuario == null )
               throw new Exception("Valor inválido para o campo Usuario.");

           if (local == null )
               throw new Exception("Valor inválido para o campo Local.");

           if (fim > inicio )
               throw new Exception("A data da reserva não é valida.");


            Inicio = inicio;
            Fim = fim;
            Usuario = usuario;
            Local = local;
        }


    }
}
