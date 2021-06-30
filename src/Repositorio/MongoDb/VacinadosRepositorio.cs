using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class VacinadosRepositorio : Repositorio<Vacinados>, IVacinadosRepositorio
    {
        public VacinadosRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }

        public Vacinados GetPorCNSouCPF(string cns, string cpf)
        {
            var data = _collection.AsQueryable().FirstOrDefault(x => x.Pessoa.CNS == cns || x.Pessoa.CPF == cpf);
            return data;
        }

        public async Task<IEnumerable<Vacinados>> GetPorNome(string nome)
        {
            var data = await _collection.FindAsync(Builders<Vacinados>.Filter.Eq("Pessoa.Nome", nome));
            return data.ToList();
        }
    }
}
