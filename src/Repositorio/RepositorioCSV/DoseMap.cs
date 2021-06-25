using System;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Dominio;

namespace RepositorioCSV
{
    public class DoseMap : ClassMap<Dose>
    {
        //vacina_dataAplicacao;vacina_fabricante_nome;vacina_grupoAtendimento_nome;
        //vacina_lote;vacina_numDose;estabelecimento_valor
        public DoseMap()
        {
            Map(m => m.DataAplicacao).Name("vacina_dataAplicacao").TypeConverterOption.Format("yyyy-MM-dd'T'HH:mm:ss'.000Z'");//2021-02-01T00:00:00.000Z
            Map(m => m.Fabricante).Name("vacina_fabricante_nome");
            Map(m => m.GrupoAtendimento).Name("vacina_grupoAtendimento_nome");
            Map(m => m.Lote).Name("vacina_lote");
            Map(m => m.NumeroDose).Name("vacina_numDose");
            Map(m => m.CNES).Name("estabelecimento_valor");
            References<PacienteMap>(m => m.Paciente);
        }

    }
}