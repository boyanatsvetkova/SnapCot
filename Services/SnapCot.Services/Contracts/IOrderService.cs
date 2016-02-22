namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;

    public interface IOrderService
    {
        void AddOrder(Order order);
    }
}
