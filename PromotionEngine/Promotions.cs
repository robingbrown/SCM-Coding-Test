using System.Linq;

namespace PromotionEngine
{
    /// <summary>
    /// Interface for all promotions
    /// </summary>
    public interface IPromotion
    {
        decimal Discount(Cart cart);
    }
    /// <summary>
    /// Buy three of product A promotion
    /// </summary>
    public class Buy3APromotion : IPromotion
    {
        public decimal Discount(Cart cart) => cart.Items.Where(x => x.ID == "A").Count() >= 3 ? 20m : 0m;    
    }
    /// <summary>
    /// Buy two of product B promotion
    /// </summary>
    public class Buy2BPromotion : IPromotion
    {
        public decimal Discount(Cart cart) => cart.Items.Where(x => x.ID == "B").Count() >= 2 ? 15m : 0m;
    }
    /// <summary>
    /// Buy product C and product D promotion
    /// </summary>
    public class BuyCnDPromotion : IPromotion
    {
        public decimal Discount(Cart cart) => cart.Items.Where(x => x.ID == "C").Count() >= 1 && cart.Items.Where(x => x.ID == "D").Count() >= 1 ? 5m : 0m;
    }
}
