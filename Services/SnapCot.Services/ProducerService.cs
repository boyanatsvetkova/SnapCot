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

        public void Add(Producer producer)
        {
            this.producers.Add(producer);
            this.producers.SaveChanges();
        }

        public IQueryable<Producer> All()
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< public/listproducts
            return this.producers.All().OrderBy(p => p.Name);
=======
            return this.producers
                .All()
                .OrderByDescending(p => p.DateAdded)
                .Take(5);
>>>>>>> local
=======
=======
>>>>>>> master
            return this.producers
                .All()
                .OrderBy(p => p.DateAdded)
                .Take(5);
<<<<<<< HEAD
>>>>>>> master
=======
>>>>>>> master
        }
    }
}
