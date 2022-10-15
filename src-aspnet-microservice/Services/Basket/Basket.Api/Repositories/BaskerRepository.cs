using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.Api.Repositories
{
    public class BaskerRepository : IBaskerRepository
    {
        private readonly IDistributedCache _distributedCache;
        public BaskerRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeleteBasket(string username)
        {
            await _distributedCache.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _distributedCache.GetStringAsync(username);
            if (string.IsNullOrEmpty(basket) == null)
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            await _distributedCache.SetStringAsync(cart.UserName,
                JsonConvert.SerializeObject(cart));
            return await GetBasket(cart.UserName);

        }
    }
}
