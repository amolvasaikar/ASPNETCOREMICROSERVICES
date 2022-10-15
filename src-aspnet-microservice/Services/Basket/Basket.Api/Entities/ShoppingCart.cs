namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public List<ShoppingCartItems> Items  { get; set; } = new List<ShoppingCartItems>();

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalProce 
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Price * item.Quantity;
                }
                return total;
            }
        }
    }
}
