using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDb
{
    public class DoseRepositorio : Repositorio<Dose>, IDoseRepositorio
    {
        public DoseRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }
        public async Task<IEnumerable<Dose>> GetPorFabricante(string fabricante)
        {
            var data = await _collection.FindAsync(Builders<Dose>.Filter.Eq("Fabricante", fabricante));
            return data.ToList();
        }
    }
}
