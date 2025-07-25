using Microsoft.AspNetCore.Mvc;

namespace order_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly List<Order> Orders = new();

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return Orders;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(Guid id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return order;
        }

        [HttpPost]
        public ActionResult<Order> Create(Order order)
        {
            // TODO: Verify car status with car-listing-service
            Orders.Add(order);
            // TODO: Publish 'order-created' event to RabbitMQ
            return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(Guid id, [FromBody] string status)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            order.Status = status;
            if (status == "paid")
                order.PaidAt = DateTime.UtcNow;
            // TODO: Publish 'order-paid' event to RabbitMQ
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            Orders.Remove(order);
            return NoContent();
        }
    }
} 