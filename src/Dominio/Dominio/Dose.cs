using System;

namespace Dominio
{
    public class Dose
    {
        public Paciente Paciente { get; set; }
        public DateTime DataAplicacao { get; set; }
        public string Fabricante { get; set; }
        public string GrupoAtendimento { get; set; }
        public string Lote { get; set; }
        public string NumeroDose { get; set; }
        public string CNES { get; set; }
    }
}

