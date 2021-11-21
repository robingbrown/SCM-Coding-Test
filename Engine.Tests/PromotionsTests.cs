using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Tests
{
    public class PromotionsTests
    {
        [Fact]
        public void BulkPurchasePromotionTest()
        {
            //Arrange
            Cart cart = new();
            cart.AddItem(new Product() { ID = "A", Price = 50m }, 3);
            IPromotion bulkPurchase = new BulkPurchasePromotion("A", 3, 20m);

            //Act
            decimal discount = bulkPurchase.Discount(cart);

            //Assert
            Assert.Equal(20m, discount);
        }
        [Fact]
        public void MatchedProductsPromotionTest()
        {
            //Arrange
            Cart cart = new();
            cart.AddItem(new Product() { ID = "C", Price = 20m }, 1);
            cart.AddItem(new Product() { ID = "D", Price = 15m }, 1);
            IPromotion matchedProducts = new MatchedProductsPromotion("C", "D", 5m);

            //Act
            decimal discount = matchedProducts.Discount(cart);

            //Assert
            Assert.Equal(5m, discount);
        }
    }
}
