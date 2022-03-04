using System;
using System.Collections.Generic;
using System.Linq;

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

        public DateTime DataVacinacao
        {
            get
            {
                return Doses.OrderByDescending(x => x.DataAplicacao).FirstOrDefault().DataAplicacao;
            }
        }
    }
}

