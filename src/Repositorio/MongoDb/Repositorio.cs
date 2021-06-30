using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Dominio;
using Dominio.Repositorio;

namespace MongoDb
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
        private readonly Contexto<T> _contexto;
        protected readonly IMongoCollection<T> _collection;

        public Repositorio(string connectionString, string nomeBanco)
        {
            _contexto = new Contexto<T>(connectionString, nomeBanco);
            _collection = _contexto.GetCollection<T>(typeof(T).Name);
        }

        public virtual Task InserirAsync(T entidade)
        {
            return _collection.InsertOneAsync(entidade);
        }

        public async Task InserirAsync(IEnumerable<T> entidades)
        {
            await _collection.InsertManyAsync(entidades);
        }

        public async Task<T> BuscarPorId(string id)
        {
            var data = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> Todos()
        {
            var all = await _collection.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public Task AtualizarAsync(T entidade)
        {
            return _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entidade.Id), entidade);
        }

        public Task Remover(string id)
        {
            return _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }

        public void Inserir(T entidade)
        {
            _collection.InsertOneAsync(entidade);
        }

        public void Atualizar(T entidade)
        {
            _collection.ReplaceOne(Builders<T>.Filter.Eq("_id", entidade.Id), entidade);
        }
    }
}
