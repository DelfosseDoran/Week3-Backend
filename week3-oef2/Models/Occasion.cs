using System;

namespace week3_oef2.Models
{
    public class Occasion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? OccasionId { get; set; }
        public string? Description { get; set; }
    }
}
