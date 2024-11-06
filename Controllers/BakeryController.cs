using InterviewChallenge.API.Behaviour.Bakery;
using InterviewChallenge.API.DataAccess.Bakery;
using InterviewChallenge.API.Models;
using LiteDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly IBakeryBehaviour _iBakeryBehaviour;

        public BakeryController(IBakeryBehaviour iBakeryBehaviour)
        {
            _iBakeryBehaviour = iBakeryBehaviour;
        }
        // GET: api/bakery
        [HttpGet]
        public async Task<ActionResult<List<BakeryItem>>> Get()
        {
            try
            {
                var items = await _iBakeryBehaviour.GetAllBakeryItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving bakery items.", Details = ex.Message });
            }
        }

        // POST: api/bakery
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BakeryItem>> Post([FromBody] BakeryItem item)
        {
            try { 
                await _iBakeryBehaviour.AddBakeryItem(item);
                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the bakery item.", Details = ex.Message });
            }
        }

        // GET: api/bakery/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<BakeryItem>> GetById(ObjectId id)
        {
            try { 
                var item = await _iBakeryBehaviour.GetBakeryItemById(id);
                if (item == null)
                    return NotFound();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the bakery item.", Details = ex.Message });
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(ObjectId id, [FromBody] BakeryItem item)
        {
            try
            {
                var existingItem = await _iBakeryBehaviour.GetBakeryItemById(id);
                if (existingItem == null)
                    return NotFound();

                existingItem.Name = item.Name;
                existingItem.Price = item.Price;

                await _iBakeryBehaviour.AddBakeryItem(existingItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the bakery item.", Details = ex.Message });
            }

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ObjectId id)
        {
            try
            {
                var existingItem = await _iBakeryBehaviour.GetBakeryItemById(id);
                if (existingItem == null)
                    return NotFound();

                await _iBakeryBehaviour.DeleteBakeryItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while removing the bakery item.", Details = ex.Message });
            }
        }
    }
}
