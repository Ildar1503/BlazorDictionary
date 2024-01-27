using BlazorWebLanguageLearn.Domain;

namespace BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces
{
    public interface IGetTranslateService<T>
    {
        //Получениение перевода слов.
        public Task<BaseResponse<T>> GetTranslateById(string id);
    }
}
