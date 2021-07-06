using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Vacinados : Entidade
    {
        public Vacinados()
        {
            Doses = new HashSet<Dose>();
        }
        public Pessoa Pessoa { get; set; }
        public GrupoDeAtendimento GrupoDeAtendimento { get; set; }
        public HashSet<Dose> Doses { get; set; }
    }
}

