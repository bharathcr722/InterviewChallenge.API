using InterviewChallenge.API.Models;
using LiteDB;

namespace InterviewChallenge.API.DataAccess.Bakery
{
    public class BakeryDataAccess:IBakeryDataAccess
    {
        private DBService _dbService;
        private IConfiguration _configuration;
        public BakeryDataAccess(DBService dbService, IConfiguration configuration)
        {
            _dbService = dbService;
            _configuration = configuration;
        }
        // Add, Update, Delete BakeryItem
        public async Task AddBakeryItem(BakeryItem item)
        {
            await Task.Run(() =>
            {
                using var db =_dbService.GetDatabase();
                var collection = db.GetCollection<BakeryItem>("bakeryitems");
                collection.Insert(item);
            });
        }

        // Get all BakeryItems
        public async Task<List<BakeryItem>> GetAllBakeryItems()
        {
            return await Task.Run(() =>
            {
                using var db = _dbService.GetDatabase();
                var collection = db.GetCollection<BakeryItem>("bakeryitems");
                return collection.FindAll().ToList();
            });
        }

        // Get a BakeryItem by ID
        public async Task<BakeryItem> GetBakeryItemById(ObjectId id)
        {
            return await Task.Run(() =>
            {
                using var db = _dbService.GetDatabase();
                var collection = db.GetCollection<BakeryItem>("bakeryitems");
                return collection.FindById(id);
            });
        }
        public async Task DeleteBakeryItem(ObjectId id)
        {
            using var db = _dbService.GetDatabase();
            var collection = db.GetCollection<BakeryItem>("bakeryItems");

            var result = await Task.Run(() => collection.Delete(id));

            if (!result)
            {
                throw new Exception("Item not found");
            }
        }

    }
}
