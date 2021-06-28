using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IDoseRepositorio : IRepositorio<Dose>
    {
        Task<IEnumerable<Dose>> GetPorFabricante(string fabricante);
    }
}
