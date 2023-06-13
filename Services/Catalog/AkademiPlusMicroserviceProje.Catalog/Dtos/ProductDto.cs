using AkademiPlusMicroserviceProje.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiPlusMicroserviceProje.Catalog.Dtos
{
    public class ProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryID { get; set; }
        public CategoryDto Category { get; set; }
    }
}
