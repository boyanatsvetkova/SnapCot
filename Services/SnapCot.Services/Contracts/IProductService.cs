namespace SnapCot.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IProductService
    {
        int CountProducts();

        IQueryable<Product> All(int page);
    }
}
