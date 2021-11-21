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

            // Now apply any discounts for the various promotions
            List<decimal> discounts = new();
            foreach(IPromotion promotion in promotions)
            {
                discounts.Add(promotion.Discount(cart));
            }

            // Return order total minus the largest discount
            return totalOrderValue - discounts.Max();
        }
    }
}
