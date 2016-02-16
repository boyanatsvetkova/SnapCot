namespace SnapCot.Services
{
    using System;
    using System.Linq;
    using Data.Models;
    using Data.Repositories;
    using SnapCot.Services.Contracts;

    public class CountryService : ICountryService
    {
        private IRepository<Country> countries;

        public CountryService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries.All();
        }
    }
}
