using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class ProcessarVacinadosCSV
    {
        public static IEnumerable<VacinadosViewModel> Get(string path){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
            try
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<VacinadosMap>();
                    return csv.GetRecords<VacinadosViewModel>().ToList();
                }
            }
            catch (System.Exception ex)
            {
                //TODO: adicionar log pra exception
                return null;
            }
            
        }
    }
}