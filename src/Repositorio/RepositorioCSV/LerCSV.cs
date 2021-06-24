using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RepositorioCSV
{
    public class LerCSV<T> where T : class
    {
        public IEnumerable<T> Ler(string path)
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                 return csv.GetRecords<T>().ToList();    
            }

        }
    }
}
