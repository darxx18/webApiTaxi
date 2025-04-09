using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _ordersService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<Orders>> GetOrder(int ID)
        {
            var order = await _ordersService.GetOrdersByIdAsync(ID);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Orders order)
        {
            await _ordersService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { ID = order.ID }, order); // можно заменить на Accepted() или Ok()
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Orders order)
        {
            await _ordersService.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteOrder(int ID)
        {
            await _ordersService.DeleteOrderAsync(ID);
            return NoContent();
        }
    }
}
