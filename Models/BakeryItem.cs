using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace InterviewChallenge.API.Models
{
    public class BakeryItem
    {
        [BsonId] 
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public List<Ingredient> Ingredients { get; set; }
    }
    public class Ingredient
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, 1000)]
        public decimal Quantity { get; set; }

        public string Unit { get; set; }  
    }
}
