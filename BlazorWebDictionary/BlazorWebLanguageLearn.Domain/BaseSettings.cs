using BlazorWebLanguageLearn.DAL;

namespace BlazorWebLanguageLearn.Domain
{
    public class BaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;
    }
}
