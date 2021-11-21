using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionsEngine
    {
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

            // Buy C & D promotion
            discounts.Add(cart.Items.Where(x => x.ID == "C").Count() >= 1 && cart.Items.Where(x => x.ID == "D").Count() >= 1 ? 5m : 0m);

            // Buy N Items promotion(s)
            discounts.Add(cart.Items.Where(x => x.ID == "B").Count() >= 2 ? 15m : 0m);
            discounts.Add(cart.Items.Where(x => x.ID == "A").Count() >= 3 ? 20m : 0m);

            // Return order total minus the largest discount
            return totalOrderValue - discounts.Max();
        }
    }

    public class MultiplePromotionsEngine
    {
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

            // Buy C & D promotion
            discounts.Add(cart.Items.Where(x => x.ID == "C").Count() >= 1 && cart.Items.Where(x => x.ID == "D").Count() >= 1 ? 5m : 0m);

            // Buy N Items promotion(s)
            discounts.Add(cart.Items.Where(x => x.ID == "B").Count() >= 2 ? 15m : 0m);
            discounts.Add(cart.Items.Where(x => x.ID == "A").Count() >= 3 ? 20m : 0m);

            // Return order total minus the largest discount
            return totalOrderValue - discounts.Max();
        }
    }
}
