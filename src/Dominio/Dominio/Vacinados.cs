using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Vacinados : Entidade
    {
        public Vacinados()
        {
            Doses = new List<Dose>();
        }
        public Pessoa Pessoa { get; set; }
        public GrupoDeAtendimento GrupoDeAtendimento { get; set; }
        public List<Dose> Doses { get; set; }
    }
}

