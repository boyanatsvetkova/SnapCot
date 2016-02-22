namespace SnapCot.Web.Areas.Admin.Controllers
{
    using ViewModels;
    using System.Web.Mvc;
    using Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;

    [Authorize]
    public class ProducersAdminController : Controller
    {
        private ICountryService countries;
   
        public ProducersAdminController(ICountryService countries)
        {
            this.countries = countries;
        }

        [HttpGet]
        public ActionResult AddProducer()
        {
            var model = new AddProducerInputModel
            {

            };
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducer(AddProducerInputModel model)
        {
            return View();
        }

        [ChildActionOnly]
        public IEnumerable<SelectListItem> GetCountries()
        {
            var listCountries = this.countries
                .All()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            return listCountries;
        }
    }
}