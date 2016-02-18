namespace SnapCot.Services
{
    using Contracts;
    using System.Linq;
    using Data.Models;
    using Data.Repositories;

    public class ShoppingCartService : IShoppingCartService
    {
        private IRepository<ShoppingCart> shoppingCarts;
        private IRepository<ProductCartItem> cartItems;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCarts,
            IRepository<ProductCartItem> cartItems)
        {
            this.shoppingCarts = shoppingCarts;
            this.cartItems = cartItems;
        }
    }
}
