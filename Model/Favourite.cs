using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Favourtie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("idPro")]
        public string idPro { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("price")]
        public string price { get; set; }
        [BsonElement("img")]
        public string img { get; set; }
        
        [BsonElement("username")]
        public string username { get; set; }
    }
}
