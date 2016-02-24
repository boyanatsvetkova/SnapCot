namespace SnapCot.Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Services.Contracts;
    using Infrastructure.Mapping;
    using Web.Controllers;
    using TestStack.FluentMVCTesting;
    using ViewModels.ProductViewModels;
    using System.Net;

    [TestClass]
    public class ProductsContollerTests
    {
        private IProductService products;
        private IImageService images;
        private IProducerService producers;
        private ProductsController controller;

        [TestInitialize]
        public void Init()
        {
            AutoMapperInitializer();
            this.products = DataInitializer.GetProductsService();
            this.producers = DataInitializer.GetProducersService();
            this.images = DataInitializer.GetImagesService();
            this.controller = new ProductsController(this.products, this.images, this.producers);
        }

        [TestMethod]
        public void AllProductsByPageShouldBeReturned()
        {         

            this.controller
                .WithCallTo(p => p.All(1, 0, string.Empty, "asc"))
                .ShouldRenderDefaultView()
                .WithModel<AllPagedProductsViewModel>();
        }

        [TestMethod]
        public void ProductByIdShouldReturnProductDetails()
        {
            this.controller
                 .WithCallTo(p => p.Details(1))
                 .ShouldRenderDefaultView()
                 .WithModel<DetailedProductViewModel>();  
        }

        [TestMethod]
        public void ImageWithNotExistentIdShouldReturnNotFoundException()
        {
            this.controller
                .WithCallTo(i => i.Image(0))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void ImageWithValidIdShouldBeReturned()
        {
            this.controller
                .WithCallTo(i => i.Image(1))
                .ShouldRenderFileContents();
        }

        private void AutoMapperInitializer()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ProductsController).Assembly);
        }
    }
}
