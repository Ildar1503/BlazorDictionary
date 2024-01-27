namespace BlazorWebLanguageLearn.DAL.Interfacies
{
    public interface IMongoDbServices<T>
    {
        public Task<T> GetByIdAsync(string id);
        public Task<List<T>> GetAllAsync();
    }
}
