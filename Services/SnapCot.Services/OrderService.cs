namespace SnapCot.Services
{
    using System;
    using SnapCot.Data.Models;
    using SnapCot.Data.Repositories;
    using System.Linq;
    using Contracts;
    using System.Collections.Generic;

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
    }
}
