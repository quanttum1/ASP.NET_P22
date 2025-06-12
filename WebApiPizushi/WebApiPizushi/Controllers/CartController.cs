using Core.Interfaces;
using Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPizushi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUpdate([FromBody] CartCreateUpdateModel model)
        {
            var email = User.Claims.First().Value;

            // Here you would typically call a service to handle the cart logic
            // For example: await _cartService.CreateUpdate(model, UserId);
            return Ok(new { message = "Cart updated successfully" });
        }
    }
}
