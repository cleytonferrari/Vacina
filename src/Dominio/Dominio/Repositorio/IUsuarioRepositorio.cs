using Dominio.Acesso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<List<Usuario>> GetPorNome(string nome);

        Task<Usuario> GetPorLogin(string login);

        bool LoginDuplicado(string login);

        bool ExisteUsuarioNoBanco();

        Task<Usuario> Logar(string login, string senha);

    }
}
