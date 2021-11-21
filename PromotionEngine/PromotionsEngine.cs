using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionsEngine
    {
        private List<IPromotion> promotions = new();
        public PromotionsEngine()
        {
            // We are simply adding the promotions in the constructor for the moment,
            //  later on we can refactor the promotions engine to use a factory pattern to determine which promotions to use
            //  or alternatively we could make the engine static and inject the promotions into the Calculate method
            promotions.Add(new Buy2BPromotion());
            promotions.Add(new Buy3APromotion());
            promotions.Add(new BuyCnDPromotion());
        }
        public decimal Calculate(Cart cart)
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
