using InterviewChallenge.API.Behaviour.Orders;
using InterviewChallenge.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController: ControllerBase
    {
        private readonly IOrdersBehaviour _iOrdersBehaviour;

        public OrdersController(IOrdersBehaviour iOrdersBehaviour)
        {
            _iOrdersBehaviour = iOrdersBehaviour;
        }
        // GET: api/orders
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CustomerOrder>>> Get()
        {
            try
            {
                var orders = await _iOrdersBehaviour.GetCustomerOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the orders.", Details = ex.Message });
            }
        }

        // POST: api/orders
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CustomerOrder>> Post([FromBody] CustomerOrder order)
        {
            try { 
                await _iOrdersBehaviour.AddCustomerOrder(order);
                return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while ordering the bakery item.", Details = ex.Message });
            }
        }
    }
}
