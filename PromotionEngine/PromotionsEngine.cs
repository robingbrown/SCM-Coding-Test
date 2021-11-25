using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionsEngine
    {
        public static decimal Calculate(Cart cart, List<IPromotion> promotions)
        {
            decimal totalOrderValue = 0m;
            
            // Calculate the default total for the cart
            Product[] products = cart.Items;
            for (int index = 0; index < products.Length; index++)
            {
                totalOrderValue += products[index].Price;
            }

            // Check we actually have promotions
            if (promotions.Count == 0)
            {
                return totalOrderValue;
            }

            // Return order total minus the largest discount
            return totalOrderValue - promotions.Select(x => x.Discount(cart)).Max();
        }
    }
}
