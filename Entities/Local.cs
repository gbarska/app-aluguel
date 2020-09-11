using System.Collections.ObjectModel;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Local : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
        public string ImagemUrl { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }

    }
}