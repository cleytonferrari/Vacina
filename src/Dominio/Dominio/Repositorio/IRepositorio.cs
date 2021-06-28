using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        Task<T> BuscarPorId(string id);
       
        Task<IEnumerable<T>> Todos();
        
        Task Inserir(T entidade);

        Task Inserir(IEnumerable<T> entidades);

        Task Atualizar(T entidade);
        
        Task Remover(string id);
    }
}
