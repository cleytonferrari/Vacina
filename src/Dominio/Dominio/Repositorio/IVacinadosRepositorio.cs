using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IVacinadosRepositorio : IRepositorio<Vacinados>
    {
        Task<IEnumerable<Vacinados>> GetPorNome(string nome);

        Vacinados GetPorCNSouCPF(string cns, string cpf);

    }
}
