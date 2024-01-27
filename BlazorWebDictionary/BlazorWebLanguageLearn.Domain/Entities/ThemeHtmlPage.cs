using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebLanguageLearn.Domain.Entities
{
    public class ThemeHtmlPage : BaseEntityProperties
    {
        public string MarkupString { get; set; } = default!;
        public string Language { get; set; } = default!;
        public int ThemeNumber { get; set; } = default!;
    }
}
