namespace SnapCot.Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SnapCot.Web.Controllers;
    using Inrastructure.Cache;
    using Services.Contracts;
    using TestStack.FluentMVCTesting;
    using System.Collections.Generic;
    using ViewModels.ProductViewModels;
    using Infrastructure.Mapping;
    using ViewModels.ProducerViewModels;

    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;
        private ICacheService cache;
        private IProductService products;
        private IProducerService producers;

        [TestInitialize]
        public void Init()
        {
            this.AutoMapperInitializer();
            this.cache = new HttpCacheService();
            this.products = DataInitializer.GetProductsService();
            this.producers = DataInitializer.GetProducersService();
            this.controller = new HomeController(this.products, this.producers, this.cache);
        }

        [TestMethod]
        public void IndexPageShouldBeReturned()
        {
            this.controller
                .WithCallTo(p => p.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void NewProductsPartialViewIsRendered()
        {
            this.controller
                .WithCallTo(p => p.NewProducts())
                .ShouldRenderPartialView("_HomeProductPartial")
                .WithModel<IEnumerable<HomeProdcutViewModel>>();
        }

        [TestMethod]
        public void NewProducersPartialViewIsRendered()
        {
            this.controller
                .WithCallTo(p => p.NewProducers())
                .ShouldRenderPartialView("_HomeProducerPartial")
                .WithModel<IEnumerable<ProducerViewModel>>();
        }

        private void AutoMapperInitializer()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(HomeController).Assembly);
        }
    }
}
