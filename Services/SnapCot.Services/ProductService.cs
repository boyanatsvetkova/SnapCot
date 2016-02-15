namespace SnapCot.Services
{
    using System.Linq;
    using SnapCot.Data.Models;
    using SnapCot.Services.Contracts;
    using SnapCot.Data.Repositories;
    using Common;
    using System;

    public class ProductService : IProductService
    {
        private IRepository<Product> products;

        public ProductService(IRepository<Product> products)
        {
            this.products = products;
        }

        public IQueryable<Product> All(int page, int producerId, string searchString, string orderByPrice)
        {
            var products = this.products
                .All()
                .Where(p => producerId != 0 ? p.ProducerId == producerId : p.ProducerId == p.ProducerId)
                .Where(p => string.IsNullOrEmpty(searchString) || p.Name.Contains(searchString));

            if (orderByPrice == "desc")
            {
                return products.OrderByDescending(p => p.Price)
                    .Skip((page - 1) * GlobalConstants.DefaultPageSize)
                    .Take(GlobalConstants.DefaultPageSize);
            }

            return products.OrderBy(p => p.Price)
                   .Skip((page - 1) * GlobalConstants.DefaultPageSize)
                   .Take(GlobalConstants.DefaultPageSize);

        }

        public int CountProducts(string searchString)
        {
            return this.products
                .All()
                .Where(p => string.IsNullOrEmpty(searchString) || p.Name.Contains(searchString))
                .Count();
        }

        public int CountProductsByProducer(int producerId, string searchString)
        {
            return this.products
                .All()
                .Where(p => p.ProducerId == producerId)
                .Where(p => string.IsNullOrEmpty(searchString) || p.Name.Contains(searchString))
                .Count();
        }
    }
}
