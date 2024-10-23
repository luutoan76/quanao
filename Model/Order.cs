using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("dayCreate")]
        public string dayCreate { get; set; }
        [BsonElement("total")]
        public string total { get; set; }
        [BsonElement("orderItem")]
        public List<OrderItem> orderItem { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("status")]
        public string status { get; set; }

    }

    public class OrderItem{
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
