using System;
using System.Collections.ObjectModel;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Reservas
{
    public class Local : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string ImagemUrl { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
        protected Local()
        {
        }

        public Local(string nome, string descricao, string imagemUrl, Endereco endereco):base(Guid.NewGuid())
        {
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Endereco = endereco;
        }

    }
}