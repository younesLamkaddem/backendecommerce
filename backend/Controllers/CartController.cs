using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private static Cart _cart = new Cart();

        [HttpGet]
        public ActionResult<Cart> GetCart()
        {
            return _cart;
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] CartItem item)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                existingItem.Price += item.Price;
            }
            else
            {
                _cart.Items.Add(item);
            }

            _cart.TotalPrice = _cart.Items.Sum(i => i.Price);

            return Ok();
        }

        [HttpPost("Clear")]
        public ActionResult ClearCart()
        {
            _cart.Items.Clear();
            _cart.TotalPrice = 0;
            return Ok();
        }
    }
}
