namespace SnapCot.Services
{
    using System.Linq;
    using SnapCot.Data.Models;
    using SnapCot.Services.Contracts;
    using SnapCot.Data.Repositories;
    using Common;

    public class ProductService : IProductService
    {
        private IRepository<Product> products;

        public ProductService(IRepository<Product> products)
        {
            this.products = products;
        }

        public int CountProducts()
        {
            return this.products.All().Count();
        }

        public IQueryable<Product> All(int page = GlobalConstants.DefaultPage)
        {
            return this.products
                .All()
                .OrderByDescending(p => p.Price)
                .Skip((page - 1) * GlobalConstants.DefaultPageSize)
                .Take(GlobalConstants.DefaultPageSize);
        }
    }
}
