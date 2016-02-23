namespace SnapCot.Web.Controllers
{
    using SnapCot.Services.Contracts;
    using Infrastructure.Mapping;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.ProducerViewModels;
    using ViewModels.ProductViewModels;
    using Inrastructure.Cache;

    public class HomeController : Controller
    {
        private const int CacheTimeInSeconds = 60 * 60;

        private IProductService products;
        private IProducerService producers;
        private ICacheService cache;

        public HomeController(
            IProductService products, 
            IProducerService producers,
            ICacheService cache)
        {
            this.products = products;
            this.producers = producers;
            this.cache = cache;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewProducts()
        {
            var newProducts = this.cache.Get(
                "Products",
                () => this.products
                .All()
                .To<HomeProdcutViewModel>()
                .ToList(),
                CacheTimeInSeconds); 
                

            return PartialView("_HomeProductPartial", newProducts);
        }

        public ActionResult NewProducers()
        {
            var newProducers = this.cache.Get(
                "Producers",
                () => this.producers
                .All()
                .Take(5)
                .To<ProducerViewModel>()
                .ToList(),
                CacheTimeInSeconds);

            return PartialView("_HomeProducerPartial", newProducers);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}