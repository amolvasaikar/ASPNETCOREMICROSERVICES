using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    public class BasketController : ControllerBase
    {
        private readonly IBaskerRepository baskerRepository;

        public BasketController(IBaskerRepository baskerRepository)
        {
            this.baskerRepository = baskerRepository;
        }

        [HttpGet("{username}",Name ="GetBasket")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await baskerRepository.GetBasket(username);
            return Ok(basket ?? new ShoppingCart(username));
        }

        [HttpPost("UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            return Ok(await baskerRepository.UpdateBasket(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await baskerRepository.DeleteBasket(userName);
            return Ok();
        }
    }


}
