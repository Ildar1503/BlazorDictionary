using BlazorWebLanguageLearn.Domain;

namespace BlazorWebLanguageLearn.DAL
{
    public class LearnLanguageSettings : BaseSettings
    {
        public string LearnLanguageCollectionName { get; set; } = default!;
        public string FromTatarcharWordsTranslateCollectionName { get; set; } = default!;
    }

    //TODO: Найти способ наследования конфигураций
}
