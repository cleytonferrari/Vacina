using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb
{
    public class PessoaRepositorio : Repositorio<Pessoa>, IPessoaRepositorio
    {
        public async Task<IEnumerable<Pessoa>> GetPorNome(string nome)
        {
            var data = await _collection.FindAsync(Builders<Pessoa>.Filter.Eq("Nome", nome));
            return data.ToList();
        }
    }
}
