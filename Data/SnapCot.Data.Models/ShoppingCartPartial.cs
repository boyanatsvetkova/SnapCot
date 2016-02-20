namespace SnapCot.Data.Models
{
    using System.Linq;

    public partial class ShoppingCart
    {
        public string AddItem(Product product, decimal quantity)
        {
            var item = this.ProductCartItems
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (item == null)
            {
                var cartItem = new ProductCartItem
                {
                    Product = product,
                    Quantity = quantity
                };

                this.ProductCartItems.Add(cartItem);
            }
            else
            {
                return "You have already ordered this product!";
            }

            return null;
        }

        public decimal RemoveItem(int productId)
        {
            var item = this.ProductCartItems
                .Where(i => i.Product.Id == productId)
                .FirstOrDefault();

            this.ProductCartItems.Remove(item);

            return item.Quantity;
        }

        public decimal GetCartTotal()
        {
            var total = this.ProductCartItems.Sum(i => i.Quantity * i.Product.Price);
            return total;
        }

        public void Clear()
        {
            this.ProductCartItems.Clear();
        }
    }
}
