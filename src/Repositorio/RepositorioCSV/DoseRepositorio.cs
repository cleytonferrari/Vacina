using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class DoseRepositorio
    {
        public IEnumerable<Dose> Get(string path){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };

            using (var reader = new StreamReader(path))
            
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<DoseMap>();
                return csv.GetRecords<Dose>().ToList();
            }
        }
    }
}