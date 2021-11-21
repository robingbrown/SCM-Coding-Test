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
            // Buy N Items promotion
            bool buyN = cart.Items.Where(x => x.ID == "A").Count() >= 3;
            if (buyN == true)
            {
                return 130m;
            }
            //Default
            return 0m;
        }
    }
}
