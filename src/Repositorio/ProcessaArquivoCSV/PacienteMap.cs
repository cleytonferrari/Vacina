using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class PacienteMap : ClassMap<Pessoa>
    {
        //paciente_nome;paciente_enumSexoBiologico;paciente_dataNascimento;
        //vacina_dataAplicacao;vacina_fabricante_nome;vacina_grupoAtendimento_nome;
        //vacina_lote;vacina_numDose;estabelecimento_valor

        public PacienteMap()
        {
            Map(m => m.Nome).Name("paciente_nome");
            Map(m => m.Sexo).Name("paciente_enumSexoBiologico");
            //TODO: Poder escolher a formatação da data, caso o arquivo venha com data em outro formato
            Map(m => m.DataNascimento).Name("paciente_dataNascimento").TypeConverterOption.Format("yyyy-MM-dd");
        }

    }
}