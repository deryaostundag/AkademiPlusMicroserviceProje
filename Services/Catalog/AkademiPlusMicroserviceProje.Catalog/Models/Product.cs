using MongoDB.Bson.Serialization.Attributes;

namespace AkademiPlusMicroserviceProje.Catalog.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryID { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

    }
}
