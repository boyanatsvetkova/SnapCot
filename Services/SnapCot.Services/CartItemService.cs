namespace SnapCot.Services
{
    using SnapCot.Services.Contracts;
    using System;
    using Data.Models;
    using Data.Repositories;
    using System.Collections.Generic;

    public class CartItemService : ICartItemService
    {
        private IRepository<ProductCartItem> items;

        public CartItemService(IRepository<ProductCartItem> items)
        {
            this.items = items;
        }

        public void Add(IEnumerable<ProductCartItem> items)
        {
            foreach (var item in items)
            {
                this.items.Add(item);
            }
           
            this.items.SaveChanges();
        }
    }
}
