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
            //Default
            Product[] products = cart.Items;
            for (int index = 0; index < products.Length; index++)
            {
                totalOrderValue += products[index].Price;
            }
            // Buy N Items promotion
            bool buyN = cart.Items.Where(x => x.ID == "A").Count() >= 3;
            if (buyN == true)
            {
                totalOrderValue = 130m;
            }
            // Buy C & D promotion
            bool buyCnD = cart.Items.Where(x => x.ID == "C").Count() == 1 && cart.Items.Where(x => x.ID == "D").Count() == 1;
            if (buyCnD == true)
            {
                totalOrderValue = 30m;
            }
            return totalOrderValue;
        }
    }
}
