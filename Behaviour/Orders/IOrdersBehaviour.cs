using InterviewChallenge.API.Models;

namespace InterviewChallenge.API.Behaviour.Orders
{
    public interface IOrdersBehaviour
    {
        Task AddCustomerOrder(CustomerOrder order);
        Task<List<CustomerOrder>> GetCustomerOrders();
    }
}
