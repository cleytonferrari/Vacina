using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class EstatisticaRepositorio : Repositorio<Vacinados>, IEstatisticaRepositorio
    {
        public EstatisticaRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }

        public Task<int> TotalImunizado()
        {
            var data = _collection.AsQueryable().Where(x =>
                x.Doses.Any(y => y.NumeroDose == "2") || x.Doses.Any(y => y.NumeroDose == "8")
            ).CountAsync();
            return data;
        }

        public Task<int> TotalPorSexoImunizado(string sexo)
        {
            //1 - primeira dose
            //2 - segunda dose
            //8 - dose unica
            var data = _collection.AsQueryable().Where(x =>
                x.Pessoa.Sexo == sexo.ToString()
                && (x.Doses.Any(y => y.NumeroDose == "2") || x.Doses.Any(y => y.NumeroDose == "8"))
            ).CountAsync();
            return data;
        }
    }
}
