using IvorySaga.Data;
using IvorySaga.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IvorySaga.Services
{
    public class ChapterRepository
    {
        private readonly IMongoCollection<Chapter> _chapters;

        public ChapterRepository(IIvorySagaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _chapters = database.GetCollection<Chapter>(settings.ChaptersCollectionName);
        }

        public async Task<List<Chapter>?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return (await _chapters.FindAsync(chapter => chapter.SagaId == id, cancellationToken: cancellationToken)).ToList(cancellationToken);
        }

        public async Task<Chapter?> GetAsync(Guid sagaId, Guid chapterId, CancellationToken cancellationToken = default)
        {
            return (await _chapters.FindAsync<Chapter>(chapter => chapter.SagaId == sagaId && chapter.Id == chapterId, cancellationToken: cancellationToken)).FirstOrDefault(cancellationToken);
        }

        public async Task<Chapter> CreateAsync(Chapter chapter, CancellationToken cancellationToken = default)
        {
            try
            {
                await _chapters.InsertOneAsync(chapter, cancellationToken: cancellationToken);
            }
            catch (MongoWriteException e)
            {
                throw new ChapterNotCreatedException(chapter.SagaId.ToString(), chapter.Id.ToString(), e);
            }

            return chapter;
        }

        public Task UpdateAsync(string id, Chapter chapterIn, CancellationToken cancellationToken = default)
        {
            return _chapters.ReplaceOneAsync(chapter => chapter.Id.ToString() == id, chapterIn, cancellationToken: cancellationToken);
        }

        public Task RemoveAsync(Chapter chapterIn, CancellationToken cancellationToken = default)
        {
            return _chapters.DeleteOneAsync(chapter => chapter.Id == chapterIn.Id, cancellationToken: cancellationToken);
        }

        public Task RemoveAsync(string id, CancellationToken cancellationToken = default)
        {
            return _chapters.DeleteOneAsync(chapter => chapter.Id.ToString() == id, cancellationToken: cancellationToken);
        }
    }
}
