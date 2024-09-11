using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /*
        [BsonElement("idPro")]
        public string idPro { get; set; }
        
        [BsonElement("namePro")]
        public string namePro { get; set; }

        [BsonElement("price")]
        public string price { get; set; }
        [BsonElement("imageUrl")]
        public string imageUrl { get; set; }

        [BsonElement("quantity")]
        public string quantity { get; set; }
        [BsonElement("nameUser")]
        public string nameUser { get; set; }*/
        [BsonElement("idPro")]
        public List<string> idPro { get; set; }
        
        [BsonElement("total")]
        public string total { get; set; }

        [BsonElement("nameUser")]
        public string nameUser { get; set; }

    }
}
