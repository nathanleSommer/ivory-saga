using IvorySaga.Data;
using IvorySaga.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Services
{
    public class SagaRepository
    {
        private readonly IMongoCollection<Saga> _sagas;

        public SagaRepository(IIvorySagaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sagas = database.GetCollection<Saga>(settings.SagasCollectionName);
        }

        public async Task<List<Saga>?> Get(CancellationToken cancellationToken = default)
        {
            var sagaCursor = await _sagas.FindAsync(saga => true, cancellationToken: cancellationToken);
            var sagas = await sagaCursor.ToListAsync(cancellationToken);
            return sagas;
        }

        public async Task<Saga?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var sagaCursor = _sagas.Find(saga => saga.Id == id);
            var saga = await sagaCursor.FirstOrDefaultAsync(cancellationToken);
            return saga;
        }

        public async Task<Saga> CreateAsync(Saga saga, CancellationToken cancellationToken = default)
        {
            try
            {
                await _sagas.InsertOneAsync(saga, cancellationToken: cancellationToken);
            } catch(MongoWriteException e)
            {
                throw new SagaNotCreatedException(saga.Id.ToString(), e);
            }

            return saga;
        }

        public Task UpdateAsync(Guid id, Saga sagaIn, CancellationToken cancellationToken = default)
        {
            return _sagas.ReplaceOneAsync(saga => saga.Id == id, sagaIn, cancellationToken: cancellationToken);
        }

        public Task RemoveAsync(Saga sagaIn, CancellationToken cancellationToken = default) {
            return _sagas.DeleteOneAsync(saga => saga.Id == sagaIn.Id, cancellationToken: cancellationToken);
        }


        public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default) {
            return _sagas.DeleteOneAsync(saga => saga.Id == id, cancellationToken: cancellationToken);
        }
    }
}
