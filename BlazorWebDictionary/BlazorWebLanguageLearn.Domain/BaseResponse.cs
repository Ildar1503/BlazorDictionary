using BlazorWebLanguageLearn.Domain.Enums;

namespace BlazorWebLanguageLearn.Domain
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; } = default!;
        public StatusCode StatusCode { get; set; }
        public T? Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}
