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
    /// Buy a number of products to receive a discount
    /// </summary>
    public class BulkPurchasePromotion : IPromotion
    {
        string myProductID;
        int myQuantity;
        decimal myDiscount;
        public BulkPurchasePromotion(string productid, int quantity, decimal discount)
        {
            myProductID = productid;
            myQuantity = quantity;
            myDiscount = discount;
        }
        public decimal Discount(Cart cart) => cart.Items.Where(x => x.ID == myProductID).Count() >= myQuantity ? myDiscount : 0m;
    }
    /// <summary>
    /// Buy two different products to receive a discount
    /// </summary>
    public class MatchedProductsPromotion : IPromotion
    {
        string myFirstProductID;
        string mySecondProductID;
        decimal myDiscount;
        public MatchedProductsPromotion(string firstproductid, string secondproductid, decimal discount)
        {
            myFirstProductID = firstproductid;
            mySecondProductID = secondproductid;
            myDiscount = discount;
        }
        public decimal Discount(Cart cart) => cart.Items.Where(x => x.ID == myFirstProductID).Count() >= 1 && cart.Items.Where(x => x.ID == mySecondProductID).Count() >= 1 ? myDiscount : 0m;
    }
}
