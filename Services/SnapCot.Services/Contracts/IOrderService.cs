namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Collections.Generic;

    public interface IOrderService
    {
        int AddOrder(Order order);
    }
}
