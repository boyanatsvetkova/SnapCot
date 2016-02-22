namespace SnapCot.Services
{
    using System;
    using System.Linq;
    using Data.Models;
    using SnapCot.Services.Contracts;
    using Data.Repositories;

    public class ProducerService : IProducerService
    {
        private IRepository<Producer> producers;

        public ProducerService(IRepository<Producer> producers)
        {
            this.producers = producers;
        }

        public IQueryable<Producer> All()
        {
<<<<<<< public/listproducts
            return this.producers.All().OrderBy(p => p.Name);
=======
            return this.producers
                .All()
                .OrderByDescending(p => p.DateAdded)
                .Take(5);
>>>>>>> local
        }
    }
}
