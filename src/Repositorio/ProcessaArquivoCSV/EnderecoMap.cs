using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        
        public EnderecoMap()
        {
            Map(m => m.Municipio).Name("paciente_endereco_nmMunicipio");
            Map(m => m.UF).Name("paciente_endereco_uf");
            Map(m => m.Bairro).Name("paciente_endereco_bairro");
        }

    }
}