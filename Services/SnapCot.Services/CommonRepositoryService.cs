namespace SnapCot.Services
{
    using System;
    using System.Linq;
    using SnapCot.Data.Models;
    using SnapCot.Services.Contracts;
    using Data.Repositories;

    public class CommonRepositoryService : ICommonRepositoryService
    {
        private IRepository<HazardClassification> classifications;
        private IRepository<Industry> industries;

        public CommonRepositoryService(
            IRepository<HazardClassification> classifications,
            IRepository<Industry> industries)
        {
            this.classifications = classifications;
            this.industries = industries;
        }

        public IQueryable<HazardClassification> AllClassifications()
        {
            return this.classifications.All();
        }

        public IQueryable<Industry> AllIndustries()
        {
            return this.industries.All();
        }
    }
}
