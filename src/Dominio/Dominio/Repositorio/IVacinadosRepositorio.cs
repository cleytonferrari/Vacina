using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IVacinadosRepositorio : IRepositorio<Vacinados>
    {
        Task<List<Vacinados>> GetPorNome(string nome);

        Task<Vacinados> GetPorCNSouCPF(string cns, string cpf);

        Task<List<GrupoDeAtendimento>> GetGruposDeAtendimento();

        Task<int> GetTotalDose(string numeroDose);

        Task<List<Vacinados>> GetPorNomeDaVacina(string nome);

    }
}
