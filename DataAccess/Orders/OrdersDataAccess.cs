using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.DataAccess.Orders
{
    public class OrdersDataAccess: IOrdersDataAccess
    {
        private DBService _dbService;
        public OrdersDataAccess(DBService dbService)
        {
            _dbService = dbService;
        }
        // Add a CustomerOrder
        public async Task AddCustomerOrder(CustomerOrder order)
        {
            await Task.Run(() =>
            {
                using var db = _dbService.GetDatabase();
                var collection = db.GetCollection<CustomerOrder>("customerorders");
                collection.Insert(order);
            });
        }

        // Get all CustomerOrders 
        public async Task<List<CustomerOrder>> GetCustomerOrders()
        {
            return await Task.Run(() =>
            {
                using var db = _dbService.GetDatabase();
                var collection = db.GetCollection<CustomerOrder>("customerorders");
                return collection.FindAll().ToList();
            });
        }
    }
}
