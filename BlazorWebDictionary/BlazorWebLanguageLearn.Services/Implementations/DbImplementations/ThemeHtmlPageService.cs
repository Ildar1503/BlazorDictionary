using BlazorWebLanguageLearn.DAL.Interfacies;
using BlazorWebLanguageLearn.Domain;
using BlazorWebLanguageLearn.Domain.Entities;
using BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces;

namespace BlazorWebLanguageLearn.Services.Implementations.DbImplementations
{
    public class ThemeHtmlPageService : IThemePageHtmlService
    {
        private readonly IMongoDbServices<ThemeHtmlPage> _mongoDbServices;

        public ThemeHtmlPageService(IMongoDbServices<ThemeHtmlPage> mongoDbServices)
        {
            _mongoDbServices = mongoDbServices;
        }

        //Получение страницы по его id, с результатом ответа бд на запрос.
        public async Task<BaseResponse<ThemeHtmlPage>> GetThemePageByIdAsync(string id)
        {
            var baseResponse = new BaseResponse<ThemeHtmlPage>();
            try
            {
                var currentPage = await _mongoDbServices.GetByIdAsync(id);
                if(currentPage == null)
                {
                    baseResponse.Description = $"Данной страницы не существует";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.ItemNotFound;
                    return baseResponse;
                }
                baseResponse.Description = $"Все отлично";
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                baseResponse.Data = currentPage;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ThemeHtmlPage>()
                {
                    Description = $"[GetThemePageByIdAsync] : {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError,
                };
            }
        }

        //Получние id страниц.
        public async Task<BaseResponse<List<string>>> GetThemePagesIdAsync()
        {
            var baseResponse = new BaseResponse<List<string>>();
            try
            {
                var pages = await _mongoDbServices.GetAllAsync();
                if(pages == null)
                {
                    baseResponse.StatusCode = Domain.Enums.StatusCode.ItemIsNull;
                    baseResponse.Description = "Страниц не существует";
                    return baseResponse;
                }

                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                baseResponse.Description = "Все отлично";
                baseResponse.Data = pages.Select(page => page.Id).ToList();

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<string>>()
                {
                    Description = $"[GetThemePagesIdAsync] : {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError,
                };
            }
        }
    }
}
