using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IDoseRepositorio : IRepositorio<Dose>
    {
        public Task<IEnumerable<Dose>> GetPorFabricante(string fabricante);
    }
}
