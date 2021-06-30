using CsvHelper.Configuration;
using Dominio;
using System.Collections.Generic;

namespace RepositorioCSV
{
    public class VacinadosViewModel 
    {
        public Pessoa Pessoa { get; set; }
        public GrupoDeAtendimento GrupoDeAtendimento { get; set; }
        public Dose Dose { get; set; }
    }
}