using MongoDB.Bson.Serialization.Attributes;

namespace BlazorWebLanguageLearn.Domain.Entities
{
    public class BaseEntityProperties
    {
        [BsonId]
        public string Id { get; set; } = default!;
    }
}
