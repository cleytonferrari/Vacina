using CsvHelper.Configuration;

namespace RepositorioCSV
{
    public class VacinadosMap : ClassMap<VacinadosViewModel>
    {


        public VacinadosMap()
        {
            References<PessoaMap>(m => m.Pessoa);
            References<GrupoDeAtendimentoMap>(m => m.GrupoDeAtendimento);
            References<DoseMap>(m => m.Dose);
        }

    }
}