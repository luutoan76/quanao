using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nameUser")]
        public string nameUser { get; set; }
        [BsonElement("review")]
        public string review { get; set; }
        [BsonElement("idPro")]
        public string idPro{get; set; }
        [BsonElement("like")]
        public string like { get; set; }

        [BsonElement("avatar")]
        public string avatar { get; set; }
        

    }
}
