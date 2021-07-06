using System;

namespace Dominio
{
    public class Dose : Entidade
    {
        public Vacina Vacina { get; set; }
        public DateTime DataAplicacao { get; set; }//vacina_dataAplicacao;
        public string Lote { get; set; }//vacina_lote;
        public string DescricaoDose { get; set; }//vacina_descricao_dose;
        public string NumeroDose { get; set; }//vacina_numDose;;
        public EstabelecimentoDeSaude EstabelecimentoDeSaude { get; set; }
    }
}