namespace SnapCot.Web.Areas.Admin.Controllers
{
    using Services.Contracts;
    using Data.Models;
    using SnapCot.Web.Areas.Admin.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;

    [Authorize]
    public class ProductsAdminController : Controller
    {
        private IProducerService producers;
        private ICommonRepositoryService commons;
        private IProductService products;

        public ProductsAdminController(
            IProducerService producers,
            ICommonRepositoryService commons,
            IProductService products)
        {
            this.producers = producers;
            this.commons = commons;
            this.products = products;
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var industries = this.commons
                .AllIndustries()
                .Select(i => new IndustryViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsSelected = false
                })
                .ToList();
            var model = new AddProductInputModel
            {
                Producers = this.GetProducers(),
                HazardClassifications = this.GetClassifications(),
                Industries = industries
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(AddProductInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    DateAdded = DateTime.UtcNow,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    ProductType = (ProductType)model.ProductType,
                    HazardClassificationId = int.Parse(model.HazardClassificationId),
                    ProducerId = int.Parse(model.ProducerId)
                };

                var productIndustries = new List<Industry>();
                for (int i = 0; i < model.Industries.Count; i++)
                {
                    if (model.Industries[i].IsSelected)
                    {
                        productIndustries.Add(new Industry
                        {
                            Id = model.Industries[i].Id,
                            Name = model.Industries[i].Name
                        });
                    }
                }

                newProduct.Industries = productIndustries;

                if (model.UploadedImage != null)
                {
                    using (var memory = new MemoryStream())
                    {
                        model.UploadedImage.InputStream.CopyTo(memory);
                        var content = memory.GetBuffer();

                        var image = new Image
                        {
                            Content = content,
                            FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last()
                        };

                        newProduct.Image = image;
                    }
                }

                this.products.Add(newProduct);

                return Redirect("/");
            }

            return View();
        }

        private IEnumerable<SelectListItem> GetProducers()
        {
            var producers = this.producers
                .All()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            return producers;
        }

        private IEnumerable<SelectListItem> GetClassifications()
        {
            var classifications = this.commons
                .AllClassifications()
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Class
                })
                .ToList();

            return classifications;
        }
    }
}