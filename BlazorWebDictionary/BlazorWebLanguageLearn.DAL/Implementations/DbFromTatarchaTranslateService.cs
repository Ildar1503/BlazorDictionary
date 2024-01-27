using BlazorWebLanguageLearn.DAL.Interfacies;
using BlazorWebLanguageLearn.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorWebLanguageLearn.DAL.Implementations
{
    public class DbFromTatarchaTranslateService : IMongoDbServices<FromTatarchaTranslate>
    {
        private readonly IMongoCollection<FromTatarchaTranslate> _fromTatarchaCollection;

        public DbFromTatarchaTranslateService(IOptions<LearnLanguageSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var currentDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _fromTatarchaCollection = currentDb.GetCollection<FromTatarchaTranslate>(settings.Value.FromTatarcharWordsTranslateCollectionName);
        }

        public async Task<List<FromTatarchaTranslate>> GetAllAsync() =>
            await _fromTatarchaCollection.Find(_ => true).ToListAsync();

        public async Task<FromTatarchaTranslate> GetByIdAsync(string id) =>
            await _fromTatarchaCollection.Find(item => item.Id == id).FirstOrDefaultAsync();
    }
}
