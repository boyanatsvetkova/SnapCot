namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IOrderService
    {
        int AddOrder(Order order);

        IQueryable<Order> All();

        void UpdateOrder(Order order);

        IQueryable<Order> GetOrderById(int id);
    }
}
