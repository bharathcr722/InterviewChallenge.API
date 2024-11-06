using InterviewChallenge.API.DataAccess.Orders;
using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.Behaviour.Orders
{
    public class OrdersBehaviour: IOrdersBehaviour
    {

        private readonly IOrdersDataAccess _ordersDataAccess;

        public OrdersBehaviour(IOrdersDataAccess ordersDataAccess)
        {
            _ordersDataAccess = ordersDataAccess;
        }
        public async Task<List<CustomerOrder>> GetCustomerOrders()
        {
            return await _ordersDataAccess.GetCustomerOrders();
        }
        public async Task AddCustomerOrder(CustomerOrder order)
        {
            await _ordersDataAccess.AddCustomerOrder(order);
        }
    }
}
