using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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

        public Task<List<GrupoDeAtendimento>> GetGruposDeAtendimento()
        {
            var data = _collection.AsQueryable().GroupBy(x => x.GrupoDeAtendimento.Nome).Select(x => x.First()).Select(x => x.GrupoDeAtendimento).ToListAsync();
            return data;
        }

        public Task<Vacinados> GetPorCNSouCPF(string cns, string cpf)
        {
            var data = _collection.AsQueryable().FirstOrDefaultAsync(x => x.Pessoa.CNS == cns || x.Pessoa.CPF == cpf);
            return data;
        }

        public Task<List<Vacinados>> GetPorNome(string nome)
        {
            var data = _collection.AsQueryable().Where(x => x.Pessoa.Nome.ToLower().Contains(nome.ToLower())).ToListAsync();
            return data;
        }

        public Task<List<Vacinados>> GetPorNomeDaVacina(string nome)
        {
            var data = _collection.AsQueryable().Where(x => x.Doses.Any(y=>y.Vacina.Nome.ToLower().Contains(nome.ToLower()))).ToListAsync();
            return data;
        }

        public Task<int> GetTotalDose(string numeroDose)
        {
            var data = _collection.AsQueryable().Where(x => x.Doses.Any(y => y.NumeroDose.ToLower() == numeroDose.ToLower())).CountAsync();
            return data;

        }
    }
}
