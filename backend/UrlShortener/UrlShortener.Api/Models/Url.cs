using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace UrlShortener.Api.Models
{
    public class Url
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("originalUrl")]
        public string OriginalUrl { get; set; } = string.Empty;

        [BsonElement("shortCode")]
        public string ShortCode { get; set; } = string.Empty;

        [BsonElement("clickCount")]
        public int ClickCount { get; set; }
  


        [BsonElement("createdAt")]
        public DateTime? CreatedAt { get; set; }
        [BsonElement("expiresAt")]
        public DateTime? ExpiresAt { get; set; }
    }
}
