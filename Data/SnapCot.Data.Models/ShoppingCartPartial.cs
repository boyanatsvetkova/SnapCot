namespace SnapCot.Data.Models
{
    using System.Linq;

    public partial class ShoppingCart
    {
        public void AddItem(Product product, decimal quantity)
        {
            var item = this.ProductCartItems
                .Where(p => p.ProdcutId == product.Id)
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
        }

        public void RemoveItem(int productId)
        {
            var item = this.ProductCartItems
                .Where(i => i.ProdcutId == productId)
                .FirstOrDefault();

            this.ProductCartItems.Remove(item);
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
