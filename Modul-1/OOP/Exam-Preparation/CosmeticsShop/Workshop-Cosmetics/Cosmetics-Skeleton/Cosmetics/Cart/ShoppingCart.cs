using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        private ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
            set { productList = value; }
        }

        public void AddProduct(IProduct product)
        {
            Validator.CheckIfNull(
                product,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull, "The added product to cart "));

            this.productList.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Validator.CheckIfNull(
                product,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull, "The checked product from cart "));

            return this.productList.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Validator.CheckIfNull(
                product,
                string.Format(
                    GlobalErrorMessages.ObjectCannotBeNull, "The removed product from cart "));

            this.productList.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal result = 0;

            foreach (var product in this.productList)
            {
                result += product.Price;
            }

            return result;
        }
    }
}
