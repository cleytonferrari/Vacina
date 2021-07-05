using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IEstatisticaRepositorio : IRepositorio<Vacinados>
    {
        Task<int> TotalPorSexoImunizado(string sexo);

        Task<int> TotalImunizado();
    }
}
