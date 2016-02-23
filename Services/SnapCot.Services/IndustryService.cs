namespace SnapCot.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Repositories;

    public class IndustryService : IIndustryService
    {
        private IRepository<Industry> industries;

        public IndustryService(IRepository<Industry> industries)
        {
            this.industries = industries;
        }

        public int Add(Industry industry)
        {
            this.industries.Add(industry);
            this.industries.SaveChanges();
            return industry.Id;
        }

        public IQueryable<Industry> All()
        {
            return this.industries.All();
        }

        public void Dispose()
        {
            this.industries.Dispose();
        }

        public Industry GetById(int id)
        {
            return this.industries.GetById(id);
        }

        public void Update(Industry industry, string name)
        {
            industry.Name = name;
            this.industries.SaveChanges();
        }
    }
}
