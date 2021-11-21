using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart
    {
        private List<Product> products = new();
        public void AddItem(Product item)
        {
            products.Add(item);
        }

        public Product[] Items() => products.ToArray();

    }
}
