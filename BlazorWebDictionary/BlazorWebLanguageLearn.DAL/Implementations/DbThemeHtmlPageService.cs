using BlazorWebLanguageLearn.DAL.Interfacies;
using BlazorWebLanguageLearn.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorWebLanguageLearn.DAL.Implementations
{
    public class DbThemeHtmlPageService : IMongoDbServices<ThemeHtmlPage>
    {
        private readonly IMongoCollection<ThemeHtmlPage> _pagesCollection;

        public DbThemeHtmlPageService(IOptions<LearnLanguageSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var currentDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _pagesCollection = currentDb.GetCollection<ThemeHtmlPage>(settings.Value.LearnLanguageCollectionName);
        }

        public async Task<List<ThemeHtmlPage>> GetAllAsync() =>
            await _pagesCollection.Find(_ => true).ToListAsync();

        public async Task<ThemeHtmlPage> GetByIdAsync(string id) =>
            await _pagesCollection.Find(item => item.Id == id).FirstOrDefaultAsync();
    }
}
