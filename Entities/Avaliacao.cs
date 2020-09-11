using System;
using Dominio.Core;

namespace Dominio.Entities
{
    public class Avaliacao : Entity
    {
        public Usuario Usuario { get; set; }
        public Local Local { get; set; }
        public decimal Nota { get; set; }
        public string Comentario {get; set; }
    }
}