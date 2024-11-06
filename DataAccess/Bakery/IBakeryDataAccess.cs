using InterviewChallenge.API.Models;
using LiteDB;

namespace InterviewChallenge.API.DataAccess.Bakery
{
    public interface IBakeryDataAccess
    {
        Task<BakeryItem> GetBakeryItemById(ObjectId id);
        Task<List<BakeryItem>> GetAllBakeryItems();
        Task AddBakeryItem(BakeryItem item);
        Task DeleteBakeryItem(ObjectId id);
    }
}
