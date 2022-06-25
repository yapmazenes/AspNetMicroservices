using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                return totalPrice;
            }
        }
    }
}
