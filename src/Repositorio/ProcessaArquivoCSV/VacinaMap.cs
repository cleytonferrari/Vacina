using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class VacinaMap : ClassMap<Vacina>
    {
       
        public VacinaMap()
        {
            References<FabricanteMap>(m => m.Fabricante);
            Map(m => m.Nome).Name("vacina_nome");
        }

    }
}