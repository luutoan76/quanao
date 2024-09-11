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
        [BsonElement("idPro")]
        public List<string> idPro { get; set; }
        [BsonElement("address")]
        public string address { get; set; }
        [BsonElement("username")]
        public string username { get; set; }

        [BsonElement("status")]
        public string status { get; set; }

    }
}
