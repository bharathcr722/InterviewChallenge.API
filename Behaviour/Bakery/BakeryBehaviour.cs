using InterviewChallenge.API.DataAccess.Bakery;
using InterviewChallenge.API.Models;
using LiteDB;

namespace InterviewChallenge.API.Behaviour.Bakery
{
    public class BakeryBehaviour: IBakeryBehaviour
    {
        private readonly IBakeryDataAccess _bakeryDataAccess;

        public BakeryBehaviour(IBakeryDataAccess bakeryDataAccess)
        {
            _bakeryDataAccess = bakeryDataAccess;
        }
        public async Task<BakeryItem> GetBakeryItemById(ObjectId id)
        {
            return await _bakeryDataAccess.GetBakeryItemById(id);
        }
        public async Task<List<BakeryItem>> GetAllBakeryItems()
        {
            return await _bakeryDataAccess.GetAllBakeryItems();
        }
        public async Task AddBakeryItem(BakeryItem item)
        {
             await _bakeryDataAccess.AddBakeryItem(item);
        }
        public async Task DeleteBakeryItem(ObjectId id)
        {
            await _bakeryDataAccess.DeleteBakeryItem(id);
        }
    }
}
