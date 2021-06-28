using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Task<IEnumerable<Pessoa>> GetPorNome(string nome);
    }
}
