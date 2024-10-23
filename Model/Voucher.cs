using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace quanao.Models
{
    public class Voucher
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nameVoucher")]
        public string nameVoucher { get; set; }
        [BsonElement("imgVoucher")]
        public string imgVoucher { get; set; }
        [BsonElement("description")]
        public string description { get; set; }
        [BsonElement("startTime")]
        public string startTime { get; set; }
        [BsonElement("endTime")]
        public string endTime { get; set; }
        [BsonElement("discount")]
        public string discount { get; set; }

        [BsonElement("amount")]
        public string amount { get; set; }
    }
}
