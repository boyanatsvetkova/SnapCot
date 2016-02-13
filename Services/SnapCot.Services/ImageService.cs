namespace SnapCot.Services
{
    using SnapCot.Data.Models;
    using SnapCot.Data.Repositories;
    using Contracts;
    using System;
    using System.Linq;

    public class ImageService : IImageService
    {
        IRepository<Image> images;

        public ImageService(IRepository<Image> images)
        {
            this.images = images;
        }

        public Image GetById(int? id)
        {
            return this.images
                .GetById(id);
        }
    }
}
