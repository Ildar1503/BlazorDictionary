#region Usings

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using BlazorWebLanguageLearn.DAL;
using BlazorWebLanguageLearn.DAL.Implementations;
using BlazorWebLanguageLearn.DAL.Interfacies;
using BlazorWebLanguageLearn.Domain.Entities;
using BlazorWebLanguageLearn.Services.Implementations.AddMarkupString;
using BlazorWebLanguageLearn.Services.Implementations.DbImplementations;
using BlazorWebLanguageLearn.Services.Implementations.DictionaryImplementations;
using BlazorWebLanguageLearn.Services.Interfaces.AddMarkupStringInterfaces;
using BlazorWebLanguageLearn.Services.Interfaces.DbInterfaces;
using BlazorWebLanguageLearn.Services.Interfaces.DictionaryInterfaces;

#endregion

namespace BlazorWebLanguageLearn
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazorise(options =>
            {
                options.Immediate = true;
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();
            services.Configure<LearnLanguageSettings>(builder.Configuration.GetSection("LearnLanguage"));
            services.AddSingleton<IMongoDbServices<ThemeHtmlPage>, DbThemeHtmlPageService>();
            services.AddSingleton<IMongoDbServices<FromTatarchaTranslate>, DbFromTatarchaTranslateService>();
            services.AddTransient<IWorkWithDictionary, WorkWithDictionaryService>();
            services.AddTransient<IAddMarkupString, AddMarkupStringService>();
            services.AddTransient<IThemePageHtmlService, ThemeHtmlPageService>();
            services.AddTransient<IGetTranslateService<FromTatarchaTranslate>, GetTranslateService>();
        }
    }
}
