namespace SnapCot.Web.Areas.Private.Controllers
{
    using Services.Contracts;
    using ViewModels;
    using System.Linq;
    using System.Web.Mvc;
    using Web.ViewModels.ProductViewModels;
    using Common;

    [Authorize]
    public class ShoppingCartController : BaseController
    {
        private const string ProductsUrl = "/Products/All";

        private IProductService products;

        public ShoppingCartController(IProductService products, IUserService users)
            :base(users) 
        {
            this.products = products;
        }

        public ActionResult Index()
        {

            var cart = new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = ProductsUrl
            };

            return View(cart);
        }

        [ChildActionOnly]
        public ActionResult GetCartSummary()
        {
            var cart = new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = ProductsUrl
            };

            return PartialView("_CartSummaryPartial", cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(AddProductInputModel model, string returnUrl)
        {
            string warningMessage = null;
            if (ModelState.IsValid)
            {
                var product = this.products.GetProdcutById(model.Id).FirstOrDefault();
                if (product != null)
                {
                    if (product.Quantity >= model.QuantityToOrder)
                    {
                        var cart = this.GetCart();
                        string addedProduct = cart.AddItem(product, model.QuantityToOrder);
                        if (addedProduct != null)
                        {
                            warningMessage = addedProduct;
                        }
                        else
                        {
                            this.products.UpdateProductQuantity(product, (decimal)model.QuantityToOrder);
                            return this.RedirectToAction("Index", new { returnUrl });
                        }
                    }
                    else
                    {   
                        warningMessage = WarningMessages.QuantityNotEnough;
                    }
                }
                else
                {
                    warningMessage = WarningMessages.ProductNotFound;
                }
            }

            this.TempData["Notification"] = warningMessage;
            return this.RedirectToAction("Details", "Products", new { area = string.Empty, id = model.Id });
        }

        public ActionResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = this.products.GetProdcutById(productId).FirstOrDefault();
            if (product == null)
            {
                this.TempData["Notification"] = WarningMessages.ProductNotFound;
            }
            else
            {
                var quantityRemoved = this.GetCart().RemoveItem(productId);
                this.products.UpdateProductQuantity(product, (quantityRemoved * -1));
            }         

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}