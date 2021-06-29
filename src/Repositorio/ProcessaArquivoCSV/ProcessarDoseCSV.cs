using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class ProcessarDoseCSV
    {
        public static IEnumerable<Dose> Get(string path){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
            try
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<DoseMap>();
                    return csv.GetRecords<Dose>().ToList();
                }
            }
            catch (System.Exception)
            {
                return null;
            }
            
        }
    }
}