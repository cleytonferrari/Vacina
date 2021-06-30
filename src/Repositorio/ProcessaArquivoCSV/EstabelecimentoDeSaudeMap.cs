using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class EstabelecimentoDeSaudeMap : ClassMap<EstabelecimentoDeSaude>
    {
        
        public EstabelecimentoDeSaudeMap()
        {
            Map(m => m.Codigo).Name("estabelecimento_valor");
            Map(m => m.Nome).Name("estalecimento_noFantasia");
        }

    }
}