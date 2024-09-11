using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("tenloai")]
        public string tenLoai { get; set; }
        [BsonElement("img")]
        public string img { get; set; }
        

    }
}
