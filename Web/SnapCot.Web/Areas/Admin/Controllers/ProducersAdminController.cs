namespace SnapCot.Web.Areas.Admin.Controllers
{
    using ViewModels;
    using System.Web.Mvc;
    using Services.Contracts;
    using System.Linq;
    using Web.ViewModels.CommonViewModels;
    using Data.Models;
    using System;
    using Inrastructure.Cache;
    using SnapCot.Common;

    [Authorize]
    public class ProducersAdminController : Controller
    {
        private ICountryService countries;
        private IProducerService producers;
        private ICacheService cache;

        public ProducersAdminController(
            ICountryService countries, 
            IProducerService producers,
            ICacheService cache)
        {
            this.countries = countries;
            this.producers = producers;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            var model = new AddProducerInputModel
            {
                Country = this.GetCountries()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducer(AddProducerInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newProducer = new Producer
                {
                    Name = model.Name,
                    Address = model.Address,
                    DateAdded = DateTime.UtcNow,
                    Email = model.Email,
                    Telephone = model.Telephone,
                    Website = model.Website,
                    CountryId = int.Parse(model.Country.CountryId)
                };

                this.producers.Add(newProducer);
            }

            return Redirect("/");
        }

        [ChildActionOnly]
        public CountryDropDownViewModel GetCountries()
        {
            var listCountries = this.cache.Get(
                "Countries",
                () => this.countries 
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList(),
                GlobalConstants.UniversalCacheTime);

            var model = new CountryDropDownViewModel
            {
                Countries = listCountries
            };

            return model;
        }
    }
}