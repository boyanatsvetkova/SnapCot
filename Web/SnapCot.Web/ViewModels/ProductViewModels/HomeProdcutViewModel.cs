namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class HomeProdcutViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Type")]
        public ProductType ProductType { get; set; }
    }
}