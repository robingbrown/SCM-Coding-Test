﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PromotionEngine;

namespace Engine.Tests
{
    public class PromotionsEngineTests
    {
        [Fact]
        public void BuyNItems()
        {
            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Cart cart = new();
            cart.AddItem(a, 3);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue =  engine.Calculate(cart);

            //Assert
            Assert.Equal(130m, totalordervalue);

        }

        [Fact]
        public void BuyCandD()
        {
            //Arrange
            Product c = new() { ID = "C", Price = 20m };
            Product d = new() { ID = "D", Price = 15m };
            Cart cart = new();
            cart.AddItem(c, 1);
            cart.AddItem(d, 1);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue = engine.Calculate(cart);

            //Assert
            Assert.Equal(30m, totalordervalue);

        }
    
        [Fact]
        public void ScenarioA()
        {
            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            Cart cart = new();
            cart.AddItem(a, 1);
            cart.AddItem(b, 1);
            cart.AddItem(c, 1);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue = engine.Calculate(cart);

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
            //Product d = new() { ID = "D", Price = 15m };
            Cart cart = new();
            cart.AddItem(a, 5);
            cart.AddItem(b, 5);
            cart.AddItem(c, 1);
            //cart.AddItem(d, 1);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue = engine.Calculate(cart);

            //Assert
            Assert.Equal(400m, totalordervalue);
        }

    }
}
