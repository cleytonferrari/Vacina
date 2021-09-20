using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class MunicipioRepositorio : Repositorio<Municipio>, IMunicipioRepositorio
    {
        public MunicipioRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }

        public Task<Municipio> GetMunicipio()
        {
            var data = _collection.AsQueryable().FirstOrDefaultAsync();
            return data;
        }
    }
}
