namespace SnapCot.Web.Areas.Private.ViewModels
{
    using SnapCot.Data.Models;

    public class ShoppingCartViewModel
    {
        public ShoppingCart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}