namespace BlazorWebLanguageLearn.Services.Interfaces.AddMarkupStringInterfaces
{
    public interface IAddMarkupString
    {
        public Task<string> GetMarkupStringTatarcha(string id);
        public Task<string> GetMarkupStringBashkort(string id);
    }
}
