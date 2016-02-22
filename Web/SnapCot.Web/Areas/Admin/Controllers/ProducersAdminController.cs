namespace SnapCot.Web.Areas.Admin.Controllers
{
    using ViewModels;
    using System.Web.Mvc;
    using Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;
<<<<<<< HEAD
<<<<<<< HEAD
    using Web.ViewModels.CommonViewModels;
    using Data.Models;
    using System;
=======
>>>>>>> master
=======
>>>>>>> master

    [Authorize]
    public class ProducersAdminController : Controller
    {
        private ICountryService countries;
<<<<<<< HEAD
<<<<<<< HEAD
        private IProducerService producers;

        public ProducersAdminController(ICountryService countries, IProducerService producers)
        {
            this.countries = countries;
            this.producers = producers;
=======
=======
>>>>>>> master
   
        public ProducersAdminController(ICountryService countries)
        {
            this.countries = countries;
<<<<<<< HEAD
>>>>>>> master
=======
>>>>>>> master
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            var model = new AddProducerInputModel
            {
<<<<<<< HEAD
<<<<<<< HEAD
                Country = this.GetCountries()
            };

            return View(model);
=======

            };
            return View();
>>>>>>> master
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
=======
>>>>>>> master
            return View();
        }

        [ChildActionOnly]
        public IEnumerable<SelectListItem> GetCountries()
<<<<<<< HEAD
>>>>>>> master
=======
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
<<<<<<< HEAD
            var model = new CountryDropDownViewModel
            {
                Countries = listCountries
            };

            return model;
=======
            return listCountries;
>>>>>>> master
=======
            return listCountries;
>>>>>>> master
        }
    }
}