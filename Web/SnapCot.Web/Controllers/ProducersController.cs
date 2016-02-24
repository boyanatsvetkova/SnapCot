namespace SnapCot.Web.Controllers
{
    using Services.Contracts;
    using ViewModels.ProducerViewModels;
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Common;

    public class ProducersController : Controller
    {
        private IProducerService producers;

        public ProducersController(IProducerService producers)
        {
            this.producers = producers;
        }

        public ActionResult All(string sortOrder, int page = GlobalConstants.DefaultPage)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            var producers = this.producers.GetProducers();

            switch (sortOrder)
            {
                case "name_desc":
                    producers = producers.OrderByDescending(p => p.Name);
                    break;
                case "Country":
                    producers = producers.OrderBy(p => p.Country.Name);
                    break;
                case "country_desc":
                    producers = producers.OrderByDescending(p => p.Country.Name);
                    break;
                default:
                    producers = producers.OrderBy(p => p.Name);
                    break;
            }

            var allProducers = producers
                .Skip((page - 1) * GlobalConstants.ProducersPerPage)
                .Take(GlobalConstants.ProducersPerPage)
                .To<ProducerViewModel>()
                .ToList();
            var totalPages = (int)Math.Ceiling(producers.Count() / (decimal)GlobalConstants.ProducersPerPage);
            var model = new PagedProducersViewModel
            {
                PageCount = totalPages,
                PageNumber = page,
                Producers = allProducers,
                Order = sortOrder
            };

            return View(model);
        }
    }
}