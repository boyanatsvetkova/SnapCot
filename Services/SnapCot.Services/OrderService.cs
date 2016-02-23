namespace SnapCot.Services
{
    using System;
    using SnapCot.Data.Models;
    using SnapCot.Data.Repositories;
    using System.Linq;
    using Contracts;

    public class OrderService : IOrderService
    {
        private IRepository<Order> orders;

        public OrderService(IRepository<Order> orders)
        {
            this.orders = orders;
        }

        public int AddOrder(Order order)
        {
            this.orders.Add(order);
            this.orders.SaveChanges();

            return order.Id;
        }

        public IQueryable<Order> All()
        {
            return this.orders.All();
        }

        public IQueryable<Order> GetOrderById(int id)
        {
            return this.orders.All().Where(o => o.Id == id);
        }

        public void UpdateOrder(Order order)
        {
            this.orders.SaveChanges();
        }
    }
}
