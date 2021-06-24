using System;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace RepositorioCSV
{
    public class ViewModelPaciente
    {
        [Index(0)]
        public string Nome { get; set; }

        [Index(1)]
        public string Sexo { get; set; }

        [Index(2)]
        public string DataNascimento { get; set; }
        
    }
}