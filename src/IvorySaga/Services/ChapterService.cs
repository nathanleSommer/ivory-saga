using IvorySaga.Data;
using IvorySaga.Mongo;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace IvorySaga.Services
{
    public class ChapterService
    {
        private readonly IMongoCollection<Chapter> _chapters;

        public ChapterService(IIvorySagaDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _chapters = database.GetCollection<Chapter>(settings.ChaptersCollectionName);
        }

        public List<Chapter>? Get(string id) =>
            _chapters.Find(chapter => chapter.SagaId.ToString() == id).ToList();

        public Chapter? Get(string sagaId, string chapterId) =>
            _chapters.Find<Chapter>(chapter => chapter.SagaId.ToString() == sagaId && chapter.Id.ToString() == chapterId).FirstOrDefault();

        public Chapter Create(Chapter chapter)
        {
            _chapters.InsertOne(chapter);
            return chapter;
        }

        public void Update(string id, Chapter chapterIn) =>
            _chapters.ReplaceOne(chapter => chapter.Id.ToString() == id, chapterIn);

        public void Remove(Chapter chapterIn) =>
            _chapters.DeleteOne(chapter => chapter.Id == chapterIn.Id);

        public void Remove(string id) =>
            _chapters.DeleteOne(chapter => chapter.Id.ToString() == id);
    }
}
