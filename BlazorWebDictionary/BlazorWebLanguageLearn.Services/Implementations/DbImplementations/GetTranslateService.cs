using BlazorWebLanguageLearn.DAL.Interfacies;
using BlazorWebLanguageLearn.Domain;
using BlazorWebLanguageLearn.Domain.Entities;
using BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces;

namespace BlazorWebLanguageLearn.Services.Implementations.DbImplementations
{
    public class GetTranslateService : IGetTranslateService<FromTatarchaTranslate>
    {
        private readonly IMongoDbServices<FromTatarchaTranslate> _mongoDbServices;

        public GetTranslateService(IMongoDbServices<FromTatarchaTranslate> mongoDbServices)
        {
            _mongoDbServices = mongoDbServices;
        }

        public async Task<BaseResponse<FromTatarchaTranslate>> GetTranslateById(string id)
        {
            var baseResponse = new BaseResponse<FromTatarchaTranslate>();
            try
            {
                //Получение переводов по id.
                var currentTranslate = await _mongoDbServices.GetByIdAsync(id);
                if (currentTranslate == null)
                {
                    baseResponse.Description = $"Перевод отсутствует";
                    baseResponse.StatusCode = Domain.Enums.StatusCode.ItemNotFound;
                    return baseResponse;
                }
                baseResponse.Description = $"Все отлично";
                baseResponse.StatusCode = Domain.Enums.StatusCode.OK;
                baseResponse.Data = currentTranslate;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<FromTatarchaTranslate>()
                {
                    Description = $"class: {nameof(GetTranslateService)} method {nameof(GetTranslateById)} : {ex.Message}",
                    StatusCode = Domain.Enums.StatusCode.InternalServerError,
                };
            }
        }
    }
}
