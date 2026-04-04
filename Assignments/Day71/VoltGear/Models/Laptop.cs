using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace VoltGear.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }   

        [Required]
        public string ModelName { get; set; } = null!;

        [Required]
        public string SerialNumber { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}