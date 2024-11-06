using InterviewChallenge.API.Models;
using LiteDB;

namespace InterviewChallenge.API.Behaviour.Bakery
{
    public interface IBakeryBehaviour
    {
        Task<BakeryItem> GetBakeryItemById(ObjectId id);
        Task<List<BakeryItem>> GetAllBakeryItems();
        Task AddBakeryItem(BakeryItem item);
        Task DeleteBakeryItem(ObjectId id);
    }
}
