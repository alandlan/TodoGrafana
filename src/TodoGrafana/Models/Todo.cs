using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoGrafana.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}