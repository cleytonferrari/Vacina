using Dominio;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace MongoDb
{
    public class Contexto<T> where T : EntidadeBase
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
       
        public IClientSessionHandle Session { get; set; }

        public Contexto()
        {
           
            RegisterConventions();

            MongoClient = new MongoClient("mongodb://localhost:27017");
            Database = MongoClient.GetDatabase("Vacina");
        }

        private static void RegisterConventions()
        {
            var pack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("MyConventions", pack, t => true);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

    }
}
