using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        
        public PessoaMap()
        {
            Map(m => m.CNS).Name("paciente_cns");
            Map(m => m.CPF).Name("paciente_cpf");
            Map(m => m.Nome).Name("paciente_nome");
            Map(m => m.Sexo).Name("paciente_enumSexoBiologico");
            Map(m => m.NomeMae).Name("paciente_nome_mae");
            //TODO: Poder escolher a formatação da data, caso o arquivo venha com data em outro formato
            Map(m => m.DataNascimento).Name("paciente_dataNascimento").TypeConverterOption.Format("yyyy-MM-dd");
        }

    }
}