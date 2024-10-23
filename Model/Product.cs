using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("des")]
        public string des { get; set; }
        [BsonElement("price")]
        public string price { get; set; }
        [BsonElement("loaisp")]
        public string loaisp {get;set;}
        [BsonElement("img")]
        public List<string> img {get;set;}
        [BsonElement("size")]
        public List<string> size {get;set;}
        [BsonElement("color")]
        public List<string> color {get;set;}
        // thu nghiem
        [BsonElement("like")]
        public string like {get;set;}


    }
}
