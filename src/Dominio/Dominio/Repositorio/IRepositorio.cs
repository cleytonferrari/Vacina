using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        Task<T> BuscarPorId(string id);
       
        Task<IEnumerable<T>> Todos();
        
        Task InserirAsync(T entidade);

        void Inserir(T entidade);

        Task InserirAsync(IEnumerable<T> entidades);

        Task AtualizarAsync(T entidade);

        void Atualizar(T entidade);
        Task Remover(string id);
    }
}
