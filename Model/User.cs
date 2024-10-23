using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("username")]
        public string username { get; set; }
        [BsonElement("pass")]
        public string pass { get; set; }
        [BsonElement("phonenum")]
        public string phonenum { get; set; }
        [BsonElement("address")]
        public string address {get;set;}
        [BsonElement("img")]
        public string img {get;set;}
        [BsonElement("dateBirth")]
        public string dateBirth {get;set;}
        [BsonElement("email")]
        public string email {get;set;}
    }

    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
