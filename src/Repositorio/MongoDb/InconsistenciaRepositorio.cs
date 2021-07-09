using Dominio;
using Dominio.Repositorio;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class InconsistenciaRepositorio : Repositorio<Vacinados>, IInconsistenciaRepositorio
    {
        public InconsistenciaRepositorio(string connectionString, string nomeBanco) : base(connectionString, nomeBanco)
        {

        }

        //TODO: usar async
        public int GetTotalDosesDiferentesAplicadasNoMesmoVacinado()
        {
            var data = GetDosesDiferentesAplicadasNoMesmoVacinado().Count;
            return data;
        }



        //TODO: Melhorar isto para quem tomar 4 doses por exemplo
        //TODO: Ta horrível isso :(
        public List<Vacinados> GetDosesDiferentesAplicadasNoMesmoVacinado()
        {
            var data = _collection.AsQueryable().Where(x => x.Doses.Count == 2).ToListAsync();
            var retorno = new List<Vacinados>();

            foreach (var item in data.Result)
                if (item.Doses[0].Vacina.Nome != item.Doses[1].Vacina.Nome)
                    retorno.Add(item);

            return retorno;
        }

        public Task<List<Vacinados>> GetInconsistenciaNoNumeroDaDoseAplicada(int numeroRegistroNoBanco, string numeroDose)
        {
            var data = _collection.AsQueryable().Where(x => x.Doses.Count == numeroRegistroNoBanco && x.Doses.Any(y => y.NumeroDose.ToLower() == numeroDose.ToLower())).ToListAsync();
            return data;
        }

        public Task<int> GetTotalInconsistenciaNoNumeroDaDoseAplicada(int numeroRegistroNoBanco, string numeroDose)
        {
            var data = _collection.AsQueryable().Where(x => x.Doses.Count == numeroRegistroNoBanco && x.Doses.Any(y => y.NumeroDose.ToLower() == numeroDose.ToLower())).CountAsync();
            return data;
        }
    }
}
