using System;

namespace RepositorioCSV
{
    public class LerCSV<T> where T : class
    {
        public IEnumerable<T> Ler(string csv)
        {
            if (string.IsNullOrEmpty(csv)) return null;
            var configuracaoCsv = new CsvConfiguration { Delimiter = ";" };
            var csvReader = new CsvReader(new StringReader(csv), configuracaoCsv);
            return csvReader.GetRecords<T>();
        }
    }
}
