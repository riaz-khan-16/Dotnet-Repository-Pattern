using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository_Pattern.Entity
{
    public class BaseEntity
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
