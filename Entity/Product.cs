
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository_Pattern.Entity
{
    public class Product:BaseEntity
    {


        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
