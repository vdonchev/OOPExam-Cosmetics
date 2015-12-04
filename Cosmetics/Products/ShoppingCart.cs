namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> cart = new List<IProduct>();

        public void AddProduct(IProduct product)
        {
            this.cart.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.cart.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.cart.Contains(product);
        }

        public decimal TotalPrice()
        {
            return this.cart.Sum(p => p.Price);
        }
    }
}