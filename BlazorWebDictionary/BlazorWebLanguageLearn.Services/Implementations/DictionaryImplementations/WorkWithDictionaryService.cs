using BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces;
using BlazorWebLanguageLearn.Services.Interfaces.DictionaryInterfaces;

namespace BlazorWebLanguageLearn.Services.Implementations.DictionaryImplementations
{
    public class WorkWithDictionaryService : IWorkWithDictionary
    {
        private readonly IThemePageHtmlService _themePageHtmlService;

        public WorkWithDictionaryService(IThemePageHtmlService themePageHtmlService)
        {
            _themePageHtmlService = themePageHtmlService;
        }

        //Полчение словаря с темами.
        public Dictionary<int, string> GetThemesDictionary(string language)
        {
            switch(language)
            {
                case "tatarcha":
                    return new Dictionary<int, string>
                    {
                        { 1, "Алфавит и особенности татарского языка" },
                        { 2, "Гласные звуки" },
                        { 3, "Построение вопросительных предложений" },
                        { 4, "Согласные звуки_ Построение утвердительных и отрицательных предлодений" },
                        { 5, "Слоги, ударения, множественные числа существительных. Построение предложений о средствах выражающих пренадлежность в единственном числе" },
                        { 6, "Цвета_ Принадлежность во множественном числе_ Числительное_ Порядковые числительные_ Графические правила" },
                        { 7, "О падежах_ Части тела у человека_ Родительный падеж_ О семье" },
                        { 8, "Обощающий урок_ О доме, квартире_ Тюрко-татарские заимствования в русском языке" },
                        { 9, "Глаголы_ Желательное и повелительное наклонение" },
                        { 10, "Приветсвие_ Направительный падеж" },
                        { 11, "Времена глаголов" },
                        { 12, "Винительный падеж" },
                        { 13, "Исходный падеж" },
                        { 14, "Прилагательные_ Степени прилагательных (сравнительная, превосходная)" },
                        { 15, "Диалоги на тему школы" },
                        { 16, "Продукты питания_ Овощи и фрукты_ Рынок" },
                        { 17, "Прошедшее категорическое время" },
                        { 18, "Деньги_ Рынок_ Магазины" },
                        { 19, "Повторение пройденного_ Прошедшее неочевидное (неопределенное) время и немного о времени" },
                        { 20, "Времена года" },
                        { 21, "Незавершенное прошедшее время" },
                    };
                case "bashkort":
                    break;
            }
            return new Dictionary<int, string>();
        }

        //Получение тем по страницам в таблице.
        public Dictionary<int, (List<int>, List<string>)> GetThemesForPage(Dictionary<int, string> keyValuePairs, int page)
        {
            List<int> themesNumbers = new List<int>();
            List<string> themesNames = new List<string>(); 

            //Получение последней и первых темы.
            int end = page * 7;
            int start = end - 6;

            for (int i = start; i <= end; i++)
            {
                themesNames.Add(keyValuePairs[i]);
                themesNumbers.Add(i);
            }

            return new Dictionary<int, (List<int>, List<string>)> { { page, (themesNumbers, themesNames) } };
        }

        //Добавление id к теме. Тема представляет ключ.
        public async Task<Dictionary<string, string>> AddDictionaryItemsDbId(Dictionary<int, string> numberThemeDictionary)
        {
            var idItems = await _themePageHtmlService.GetThemePagesIdAsync();
            Dictionary<string, string> themeIdDictionary = new Dictionary<string, string>();
            //Сортировка списка с полученными id.
            var sortedIdItems = idItems?.Data.OrderBy(idStr => int.Parse(idStr.Substring(9))).ToList();
            //Добавление в словарь темы и id.
            for (int i = 0; i < sortedIdItems!.Count; i++)
            {
                themeIdDictionary.Add(numberThemeDictionary[i + 1], sortedIdItems[i]);
            }
            return themeIdDictionary;
        }

        //Корректировка названия значения словаря.
        public Dictionary<int, string> GetCurrentLabel(Dictionary<int, string> keyValuePairs, char oldValue, char newValue)
        {
            for (int i = 1; i < keyValuePairs.Count; i++)
            {
                if (keyValuePairs[i].Contains(oldValue))
                {
                    keyValuePairs[i] = keyValuePairs[i].Replace(oldValue, newValue);
                }
            }

            return keyValuePairs;
        }
    }
}
