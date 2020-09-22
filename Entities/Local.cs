using System.Collections.ObjectModel;
using Dominio.Core;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Dominio.Entities
{
    public class Local : Entity
    {
        public string Nome { get; protected set;}
        public string Descricao { get; protected set;}
        public virtual Endereco Endereco { get; protected set;}
        public string ImagemUrl { get; protected set;}
        private readonly List<Avaliacao> _avaliacoes = new List<Avaliacao>();
        public virtual IReadOnlyList<Avaliacao> Avaliacoes => _avaliacoes.ToList();
        protected Local() : base(Guid.NewGuid())
        {
        }
        protected Local(string nome, string descricao, string imagemUrl, Endereco endereco): this()
        {
            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            ImagemUrl = imagemUrl;

        }

        public Local Criar(string nome, string descricao, string imagemUrl, Endereco endereco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Valor inválido para o campo Nome.");

            if (string.IsNullOrEmpty(descricao))
               throw new Exception("Valor inválido para o campo Descricao.");

            if (string.IsNullOrEmpty(imagemUrl))
               throw new Exception("Valor inválido para o campo ImagemUrl.");

            if ( Endereco == null )
                throw new Exception("Valor inválido para o campo Endereco.");

            return new Local(nome, descricao, imagemUrl, endereco);
        }

        public void Editar(string nome, string descricao, string imagemUrl, Endereco endereco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Valor inválido para o campo Nome.");

            if (string.IsNullOrEmpty(descricao))
               throw new Exception("Valor inválido para o campo Descricao.");

            if (string.IsNullOrEmpty(imagemUrl))
               throw new Exception("Valor inválido para o campo ImagemUrl.");

            if ( Endereco == null )
                throw new Exception("Valor inválido para o campo Endereco.");

            Nome = nome;
            Descricao = descricao;
            Endereco = endereco;
            ImagemUrl = imagemUrl;
        }
        public void Avaliar(Avaliacao avaliacao)
        {
            if (_avaliacoes.Any(x => x == avaliacao))
                throw new Exception("Essa avaliação já foi realizada.");
            
            _avaliacoes.Add(avaliacao);
        }

          public void RemoverAvaliacao(Avaliacao avaliacao)
        {
            if (!_avaliacoes.Any(x => x == avaliacao))
                throw new Exception("A avaliação não existe.");
            
            _avaliacoes.Remove(avaliacao);
        }

    }
}