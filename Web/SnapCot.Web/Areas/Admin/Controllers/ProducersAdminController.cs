namespace SnapCot.Web.Areas.Admin.Controllers
{
    using ViewModels;
    using System.Web.Mvc;
    using Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;
<<<<<<< HEAD
    using Web.ViewModels.CommonViewModels;
    using Data.Models;
    using System;
=======
>>>>>>> master

    [Authorize]
    public class ProducersAdminController : Controller
    {
        private ICountryService countries;
<<<<<<< HEAD
        private IProducerService producers;

        public ProducersAdminController(ICountryService countries, IProducerService producers)
        {
            this.countries = countries;
            this.producers = producers;
=======
   
        public ProducersAdminController(ICountryService countries)
        {
            this.countries = countries;
>>>>>>> master
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            var model = new AddProducerInputModel
            {
<<<<<<< HEAD
                Country = this.GetCountries()
            };

            return View(model);
=======

            };
            return View();
>>>>>>> master
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducer(AddProducerInputModel model)
        {
<<<<<<< HEAD
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

        public CountryDropDownViewModel GetCountries()
=======
            return View();
        }

        [ChildActionOnly]
        public IEnumerable<SelectListItem> GetCountries()
>>>>>>> master
        {
            var listCountries = this.countries
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

<<<<<<< HEAD
            var model = new CountryDropDownViewModel
            {
                Countries = listCountries
            };

            return model;
=======
            return listCountries;
>>>>>>> master
        }
    }
}