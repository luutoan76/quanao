using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class DetailOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("idPro")]
        public string idPro { get; set; }
        [BsonElement("count")]
        public string count { get; set; }
        [BsonElement("idCus")]
        public string idCus { get; set; }
        

    }
}
