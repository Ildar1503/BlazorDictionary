using BlazorWebLanguageLearn.Domain;
using BlazorWebLanguageLearn.Domain.Entities;

namespace BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces
{
    public interface IThemePageHtmlService
    {
        //Получение страницы по его id.
        public Task<BaseResponse<ThemeHtmlPage>> GetThemePageByIdAsync(string id);
        //Получение id всех страниц. 
        public Task<BaseResponse<List<string>>> GetThemePagesIdAsync();
    }
}
