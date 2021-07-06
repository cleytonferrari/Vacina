using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Vacina : Entidade
    {
        public Fabricante Fabricante { get; set; }
        public string Nome { get; set; }//vacina_nome;
    }
}

