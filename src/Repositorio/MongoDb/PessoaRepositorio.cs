using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }
        public Task<List<Pessoa>> GetPorNome(string nome)
        {
            var data = _collection.AsQueryable().Where(x => x.Nome.ToLower() == nome.ToLower()).ToListAsync();
            return data;
        }
    }
}
