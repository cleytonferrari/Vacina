using Dominio.Acesso;
using Dominio.Repositorio;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }

        public Task<Usuario> GetPorLogin(string login)
        {
            var data = _collection.AsQueryable().FirstOrDefaultAsync(x => x.Login == login);
            return data;
        }

        public Task<List<Usuario>> GetPorNome(string nome)
        {
            var data = _collection.AsQueryable().Where(x => x.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
            return data;
        }

        public bool LoginDuplicado(string login)
        {
            return GetPorLogin(login).Result is not null; ;
        }
    }
}
