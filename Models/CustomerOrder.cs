using LiteDB;
using System.ComponentModel.DataAnnotations;

namespace InterviewChallenge.API.Models
{
    public class CustomerOrder
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public List<BakeryItemOrder> ItemsOrdered { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }
    }
    public class BakeryItemOrder
    {
        public ObjectId BakeryItemId { get; set; }
        public int Quantity { get; set; }
    }
}
