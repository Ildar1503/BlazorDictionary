using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebLanguageLearn.DTO.Models
{
    public class ThemeHtmlPage
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        public string Path { get; set; } = default!;
        public string Language { get; set; } = default!;
    }
}
