namespace SnapCot.Web.Tests
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using System.IO;
    using System.Reflection;
    using Services.Contracts;
    using Moq;

    public static class DataInitializer
    {
        public static byte[] ImageInitializer()
        {
            var directory = AssemblyHelpers.GetDirectoryForAssembyl(Assembly.GetExecutingAssembly());
            var files = Directory.GetFiles(directory + "/Images/", "*.*");

            var byteArray = File.ReadAllBytes(files[0]);

            return byteArray;
        }

        public static IQueryable<Image> images = new List<Image>
        {
            new Image
            {
                Id = 1,
                Content = ImageInitializer(),
                FileExtension = "jpg"
            }
        }.AsQueryable();



        public static IQueryable<Product> products = new List<Product>
        {
            new Product
            {
                 Id = 1,
                 Name = "Dangerous Product",
                 Description = "This product is very harmful for your health",
                 DateAdded = new DateTime(2016,2,24),
                 HazardClassifiction = new HazardClassification
                 {
                       Class = "Leathal"
                 },
                 Price = 10.99M,
                 Quantity = 5.0M,
                 Producer = new Producer
                 {
                       Name = "Product producer",
                       Address = "Sofia 1000",
                       Country = new Country
                       {
                              Name = "The Sun"
                       },
                       Email = "producer@pro.com",
                       DateAdded =  new DateTime(2016,2,24),
                       Telephone = "+3580896432244"
                 },
                 ProductType = ProductType.Pellettes,
                 Industries = new List<Industry>
                 {
                       new Industry() {  Name = "Product Industry"}
                 }
            },
             new Product
            {
                 Id = 2,
                 Name = "Mildly dangerous Product",
                 Description = "You will servive this product",
                 DateAdded = new DateTime(2016,2,24),
                 HazardClassifiction = new HazardClassification
                 {
                       Class = "Survivor"
                 },
                 Price = 5.50M,
                 Quantity = 10.0M,
                 Producer = new Producer
                 {
                       Name = "Producer's producer",
                       Address = "Sofia 3000",
                       Country = new Country
                       {
                              Name = "The Moon"
                       },
                       Email = "producer@pro.com",
                       DateAdded =  new DateTime(2016,2,24),
                       Telephone = "+3580896432244"
                 },
                 ProductType = ProductType.Liquid,
                 Industries = new List<Industry>
                 {
                       new Industry() {  Name = "Mild Industry"}
                 }
            }
        }.AsQueryable();


        public static IQueryable<Producer> producers = new List<Producer>
        {
            new Producer
            {
                 Id = 1,
                 Name = "Producer's producer",
                 Address = "Sofia 3000",
                 Country = new Country
                 {
                       Name = "The Moon"
                 },
                 Email = "producer@pro.com",
                 DateAdded =  new DateTime(2016,2,24),
                 Telephone = "+3580896432244"
            },
            new Producer
            {
                 Name = "Product producer",
                 Address = "Sofia 1000",
                 Country = new Country
                 {
                         Name = "The Sun"
                 },
                 Email = "producer@pro.com",
                 DateAdded =  new DateTime(2016,2,24),
                Telephone = "+3580896432244"
            },
        }.AsQueryable();

        public static IProductService GetProductsService()
        {
            var productService = new Mock<IProductService>();

            productService.Setup(x => x.All())
                .Returns(products);

            productService.Setup(x => x.GetProdcutById(
                It.Is<int>(p => p == 1)))
                .Returns(products.Where(x => x.Id == 1));

            return productService.Object;
        }

        public static IProducerService GetProducersService()
        {
            var producersService = new Mock<IProducerService>();

            producersService.Setup(x => x.All())
                .Returns(producers);

            return producersService.Object;
        }

        public static IImageService GetImagesService()
        {
            var imagesService = new Mock<IImageService>();

            imagesService.Setup(x => x.GetById(
                It.Is<int?>(p => p == 1)))
                .Returns(images.Where(p => p.Id == 1).FirstOrDefault());

            return imagesService.Object;
        }
    }
}
