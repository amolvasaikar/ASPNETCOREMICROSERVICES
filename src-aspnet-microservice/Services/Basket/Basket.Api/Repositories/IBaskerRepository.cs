using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IBaskerRepository
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> UpdateBasket(ShoppingCart cart);
        Task DeleteBasket(string username);   
    }
}
