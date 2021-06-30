using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class FabricanteMap : ClassMap<Fabricante>
    {
        
       
        public FabricanteMap()
        {
            Map(m => m.Nome).Name("vacina_fabricante_nome");
        }

    }
}