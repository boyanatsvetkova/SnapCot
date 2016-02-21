namespace SnapCot.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IProductService
    {
        int CountProducts(string searchString);

        int CountProductsByProducer(int producerId, string searchString);

        IQueryable<Product> All(int page, int producerId, string searchString, string orderByPrice);

        IQueryable<Product> GetProdcutById(int id);

        void UpdateProductQuantity(Product product, decimal quantity);

        void Add(Product product);
    }
}
