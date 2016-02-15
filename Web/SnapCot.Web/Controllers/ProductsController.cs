namespace SnapCot.Web.Controllers
{
    using Services.Contracts;
    using Common;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;
    using ViewModels.ProductViewModels;
    using Infrastructure.Mapping;
    using ViewModels.Paging;
    using ViewModels.ProducerViewModels;

    public class ProductsController : Controller
    {
        private IProductService products;
        private IImageService images;
        private IProducerService producers;

        public ProductsController(IProductService products,
            IImageService images,
            IProducerService producers)
        {
            this.products = products;
            this.images = images;
            this.producers = producers;
        }

        [HttpGet]
        public ActionResult All(int page = GlobalConstants.DefaultPage,
                                int producerId = 0,
                                string searchString = "",
                                string value = "asc")
        {

            return View(GetModel(page, producerId, searchString, value));
        }

        [HttpPost]
        public ActionResult All(AllPagedProductsViewModel productModel)
        {
            int producerId = productModel.ProducerId;
            return View(GetModel(GlobalConstants.DefaultPage,
                producerId,
                productModel.SearchString,
                productModel.Value));
        }

        private AllPagedProductsViewModel GetModel(int page,
                                                   int producerId,
                                                   string searchString,
                                                   string value)
        {
            var allProducts = this.products
               .All(page, producerId, searchString, value)
               .To<AllProductsViewModel>()
               .ToList();

            var productModel = new AllPagedProductsViewModel
            {
                Products = allProducts,
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = GlobalConstants.DefaultPageSize,
                    TotalItems = producerId == 0 ?
                        this.products.CountProducts(searchString) : this.products.CountProductsByProducer(producerId, searchString)

                },
                ProducerId = producerId,
                Value = value,
                OrderByPrice = OrderByPrice(),
                Producers = GetAllProducers(),
                SearchString = searchString
            };

            return productModel;
        }

        [ChildActionOnly]
        public SelectList OrderByPrice()
        {
            var directions = new SelectList(new[]
                           {
                           new SelectListItem {Text = "Ascending", Value = "asc"},
                           new SelectListItem {Text = "Descending", Value = "desc"},
                       }, "Value", "Text");

            return directions;
        }

        [ChildActionOnly]
        public SelectList GetAllProducers()
        {
            var all = this.producers
                .All()
                .To<ProducerViewModel>()
                .ToList();

            return new SelectList(all, "Id", "Name");
        }

        public ActionResult Image(int? id)
        {
            if (id == null)
            {
                var dir = Server.MapPath("/Images/no_image_available.png");
                var path = Path.Combine(dir);

                return File(path, "image/png");

            }

            var image = this.images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}