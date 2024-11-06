using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.DataAccess.Orders
{
    public interface IOrdersDataAccess
    {
        Task AddCustomerOrder(CustomerOrder order);
        Task<List<CustomerOrder>> GetCustomerOrders();
    }
}
