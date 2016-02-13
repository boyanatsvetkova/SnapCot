namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Linq;

    public interface IImageService
    {
        Image GetById(int? id);
    }
}
