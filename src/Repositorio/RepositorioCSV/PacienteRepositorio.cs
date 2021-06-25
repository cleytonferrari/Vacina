using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Dominio;

namespace RepositorioCSV
{
    public class PacienteRepositorio
    {
        public IEnumerable<Paciente> Get(string path){
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<PacienteMap>();
                return csv.GetRecords<Paciente>().ToList();
            }
        }
    }
}