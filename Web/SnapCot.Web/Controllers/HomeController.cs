namespace SnapCot.Web.Controllers
{
    using SnapCot.Data.Models;
    using SnapCot.Services.Contracts;
    using Infrastructure.Mapping;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.ProducerViewModels;
    using ViewModels.ProductViewModels;

    public class HomeController : Controller
    {
        private IProductService products;
        private IProducerService producers;

        public HomeController(IProductService products, IProducerService producers)
        {
            this.products = products;
            this.producers = producers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewProducts()
        {
            var newProducts = this.products
                .All()
                .To<HomeProdcutViewModel>()
                .ToList();

            return PartialView("_HomeProductPartial", newProducts);
        }

        public ActionResult NewProducers()
        {
            var newProducers = this.producers
                .All()
                .To<ProducerViewModel>()
                .ToList();

            return PartialView("_HomeProducerPartial", newProducers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}