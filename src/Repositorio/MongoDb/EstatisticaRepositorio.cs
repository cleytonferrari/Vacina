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
            var data = _collection.AsQueryable().Where(x => x.Doses.Any(y => y.NumeroDose != "1")).CountAsync();
            return data;
        }

        public Task<int> TotalPorSexoImunizado(string sexo)
        {
            /*
                //Considera imunizado qualquer um que tenha tomado mais que uma dose != "1"
                Primeira dose -1
                Segunda dose -2
                Dose unica -8
                Dose unica -9
                Dose Reforço -38
                2ª Dose Reforço - 7
                3ª Dose Reforço - 39
                Dose Adicional -37
            */

            var data = _collection.AsQueryable().Where(x => x.Pessoa.Sexo == sexo.ToString() && (x.Doses.Any(y => y.NumeroDose != "1"))).CountAsync();
            return data;
        }
    }
}
