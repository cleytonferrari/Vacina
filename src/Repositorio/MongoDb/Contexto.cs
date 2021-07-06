using Dominio;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace MongoDb
{
    public class Contexto<T> where T : Entidade
    {
        private IMongoDatabase Database { get; set; }
        public MongoClient MongoClient { get; set; }
       
        public IClientSessionHandle Session { get; set; }

        public Contexto(string connectionString, string nomeBanco)
        {
           
            RegisterConventions();

            MongoClient = new MongoClient(connectionString);

            Database = MongoClient.GetDatabase(nomeBanco);
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
