using System;
using System.Threading;
using Dominio.Core;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set;}
        public string Cidade { get; set;}
        public int Numero { get; set; }
        public Uf Uf { get; set;}
    }
}
