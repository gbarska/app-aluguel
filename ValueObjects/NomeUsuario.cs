using System;
using System.Collections.Generic;
using Dominio.Core;

namespace Dominio.ValueObjects
{
    public class NomeUsuario 
    {
        public string Nome { get; }
        public string Sobrenome { get; }

        protected NomeUsuario()
        {
        }
        
        public NomeUsuario(string nome, string sobrenome): this()
        {

           if (string.IsNullOrWhiteSpace(nome))
               throw new Exception("O Nome não pode ser nulo");
           
           if (string.IsNullOrWhiteSpace(sobrenome))
               throw new Exception("O Sobrenome não pode ser nulo");
           
            Nome = nome.Trim();
            Sobrenome = sobrenome.Trim();
        }
    }
}