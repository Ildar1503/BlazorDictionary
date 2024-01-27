namespace BlazorWebLanguageLearn.Services.Interfaces.DictionaryInterfaces
{
    public interface IWorkWithDictionary
    {
        //Получение словаря для заполнения таблицы, для определенной страницы.
        public Dictionary<int, (List<int>, List<string>)> GetThemesForPage(Dictionary<int, string> keyValuePairs, int page);
        //Получение словаря с темами по выбранному языку.
        public Dictionary<int, string> GetThemesDictionary(string language);
        //Добавление id в объект словаря из бд.
        public Task<Dictionary<string, string>> AddDictionaryItemsDbId(Dictionary<int, string> keyValuePairs);
        //Корректировка содержимого объекта словаря.
        public Dictionary<int, string> GetCurrentLabel(Dictionary<int, string> keyValuePairs, char oldValue, char newValue);
    }
}
