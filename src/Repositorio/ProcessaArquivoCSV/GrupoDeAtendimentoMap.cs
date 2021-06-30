using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class GrupoDeAtendimentoMap : ClassMap<GrupoDeAtendimento>
    {
        
       
        public GrupoDeAtendimentoMap()
        {
            Map(m => m.Nome).Name("vacina_grupoAtendimento_nome");
        }

    }
}