using IvorySaga.Mongo;
using IvorySaga.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace IvorySaga.Services
{
    public class SagaService
    {
        private readonly IMongoCollection<Saga> _sagas;

        public SagaService(IIvorySagaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sagas = database.GetCollection<Saga>(settings.SagasCollectionName);
        }

        public List<Saga> Get() =>
            _sagas.Find(saga => true).ToList();

        public Saga Get(string id) =>
            _sagas.Find<Saga>(saga => saga.Id == id).FirstOrDefault();

        public Saga Create(Saga saga)
        {
            _sagas.InsertOne(saga);
            return saga;
        }

        public void Update(string id, Saga sagaIn) =>
            _sagas.ReplaceOne(saga => saga.Id == id, sagaIn);

        public void Remove(Saga sagaIn) =>
            _sagas.DeleteOne(saga => saga.Id == sagaIn.Id);

        public void Remove(string id) =>
            _sagas.DeleteOne(saga => saga.Id == id);
    }
}
