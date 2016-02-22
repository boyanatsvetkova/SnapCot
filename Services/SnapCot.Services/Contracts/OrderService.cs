using System;
using SnapCot.Data.Models;
using SnapCot.Data.Repositories;
using System.Linq;

namespace SnapCot.Services.Contracts
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> orders;
        private IRepository<User> users;

        public OrderService(IRepository<Order> orders,
            IRepository<User> users)
        {
            this.orders = orders;
            this.users = users;
        }

        public void AddOrder(Order order)
        {
            var supplyManager = this.users
                .All()
                .Where(u => u.Email == "snapcotmag@snap.com")
                .FirstOrDefault();
            order.SupplyManagerId = supplyManager.Id;

            this.orders.Add(order);
            this.orders.SaveChanges();
        }
    }
}
