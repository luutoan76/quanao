using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("cartItem")]
        public List<CartItem> cartItem { get; set; }
        
        [BsonElement("total")]
        public string total { get; set; }

        [BsonElement("nameUser")]
        public string nameUser { get; set; }

    }

    public class CartItem{
        [BsonElement("idPro")]
        public string idPro { get; set; }

        [BsonElement("namePro")]
        public string namePro { get; set; }
        [BsonElement("price")]
        public string price { get; set; }

        [BsonElement("img")]
        public string img { get; set; }
        
        [BsonElement("quantity")]
        public string quantity { get; set; }
        [BsonElement("color")]
        public string color { get; set; }
        [BsonElement("size")]
        public string size { get; set; }
    }
}
