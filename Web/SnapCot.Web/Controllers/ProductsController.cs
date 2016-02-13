namespace SnapCot.Web.Controllers
{
    using Services.Contracts;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Reflection;
    using System.IO;
    using ViewModels.ProductViewModels;
    using Infrastructure.Mapping;
    using ViewModels.Paging;

    public class ProductsController : Controller
    {
        private IProductService products;
        private IImageService images;

        public ProductsController(IProductService products, IImageService images)
        {
            this.products = products;
            this.images = images;
        }

        public ActionResult All(int page = GlobalConstants.DefaultPage)
        {
            var allProducts = this.products
                .All(page)
                .To<AllProductsViewModel>()
                .ToList();

            var productModel = new AllPagedProductsViewModel
            {
                Products = allProducts,
                Pagination = new PaginationViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = GlobalConstants.DefaultPageSize,
                    TotalItems = this.products.CountProducts()
                }
            };

            return View(productModel);
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