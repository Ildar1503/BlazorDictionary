using BlazorWebLanguageLearn.Services.Interfaces.AddMarkupStringInterfaces;
using BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces;

namespace BlazorWebLanguageLearn.Services.Implementations.AddMarkupString
{
    public class AddMarkupStringService : IAddMarkupString
    {
        private readonly IThemePageHtmlService _themeHtmlService;

        public AddMarkupStringService(IThemePageHtmlService themeHtmlService)
        {
            _themeHtmlService = themeHtmlService;
        }

        #region Татарский альянс.

        //Получение содержимого для каждой из страниц татарского языка.
        public async Task<string> GetMarkupStringTatarcha(string id)
        {
            var result = await _themeHtmlService.GetThemePageByIdAsync(id);
            if(result.Data.Language == "tatarcha")
            {
                return result.Data.MarkupString;
            }
            return "";
        }

        #endregion

        #region Башкирский альянс.

        //Получение содержимого для каждой из страниц башкирского языка.
        public async Task<string> GetMarkupStringBashkort(string id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
