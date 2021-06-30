using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class DoseMap : ClassMap<Dose>
    {
        
       
        public DoseMap()
        {
            References<VacinaMap>(m => m.Vacina);
            //TODO: Poder escolher a formatação da data, caso o arquivo venha com data em outro formato
            Map(m => m.DataAplicacao).Name("vacina_dataAplicacao").TypeConverterOption.Format("yyyy-MM-dd'T'HH:mm:ss'.000Z'");//2021-02-01T00:00:00.000Z
            Map(m => m.Lote).Name("vacina_lote");
            Map(m => m.DescricaoDose).Name("vacina_descricao_dose");
            Map(m => m.NumeroDose).Name("vacina_numDose");
            References<EstabelecimentoDeSaudeMap>(m => m.EstabelecimentoDeSaude);
        }

    }
}