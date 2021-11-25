using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace Engine.Tests
{
    public class ScenarioTests
    {
        [Fact]
        public void ScenarioA()
        {
            //Scenario A
            //1*A   50
            //1*B   30
            //1*C   20
            //Total 100

            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            Cart cart = new();
            cart.AddItem(a, 1);
            cart.AddItem(b, 1);
            cart.AddItem(c, 1);
            List<IPromotion> promotions = new();
            promotions.Add(new BulkPurchasePromotion("A", 3, 20m));
            promotions.Add(new BulkPurchasePromotion("B", 2, 20m));
            promotions.Add(new MatchedProductsPromotion("C", "D", 5m));

            //Act
            decimal totalordervalue = PromotionsEngine.Calculate(cart, promotions);

            //Assert
            Assert.Equal(100m, totalordervalue);
        }

        [Fact]
        public void ScenarioB()
        {
            // Note that the Scenario B given in the coding test contradicts the instruction:
            //    For this coding exercise you can assume that the promotions will be mutually exclusive; in other words if one is applied the other promotions will not apply
            // Also, there is a typo for item C, it should be 20 not 28

            //Scenario B
            //5 * A       130 + 2 * 50
            //5 * B       45 + 45 + 30
            //1 * C       28
            //Total   370

            // I am going to make the assumption that the mutually exclusive phrase overrules the scenario
            //  and that only the most valuable promotion should be applied
            //  which means that Scenario B is as follows:

            //Scenario B
            //5 * A       130 + 2*50    (230)
            //5 * B       5*30          (150)
            //1 * C       20            (20)
            //Total   400

            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            Cart cart = new();
            cart.AddItem(a, 5);
            cart.AddItem(b, 5);
            cart.AddItem(c, 1);
            List<IPromotion> promotions = new();
            promotions.Add(new BulkPurchasePromotion("A", 3, 20m));
            promotions.Add(new BulkPurchasePromotion("B", 2, 20m));
            promotions.Add(new MatchedProductsPromotion("C", "D", 5m));

            //Act
            decimal totalordervalue = PromotionsEngine.Calculate(cart, promotions);

            //Assert
            Assert.Equal(400m, totalordervalue);
        }

        [Fact]
        public void ScenarioC()
        {
            // Note that again the values given for scenario C contradict the instructions

            //Scenario C
            //3 * A 130
            //5 * B 45 + 45 + 1 * 30
            //1 * C -
            //1 * D 30
            //Total 280

            // So again I have changed the values to match the instructions

            //Scenario C
            //3 * A 130         (130)
            //5 * B 5*30        (150)
            //1 * C -           (20)
            //1 * D 30          (15)
            //Total             300

            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            Product d = new() { ID = "D", Price = 15m };
            Cart cart = new();
            cart.AddItem(a, 3);
            cart.AddItem(b, 5);
            cart.AddItem(c, 1);
            cart.AddItem(d, 1);
            List<IPromotion> promotions = new();
            promotions.Add(new BulkPurchasePromotion("A", 3, 20m));
            promotions.Add(new BulkPurchasePromotion("B", 2, 20m));
            promotions.Add(new MatchedProductsPromotion("C", "D", 5m));

            //Act
            decimal totalordervalue = PromotionsEngine.Calculate(cart, promotions);

            //Assert
            Assert.Equal(315m, totalordervalue);
        }
    }
}
