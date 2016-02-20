namespace SnapCot.Web.Areas.Private.Controllers
{
    using Services.Contracts;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Web.ViewModels.ProductViewModels;

    public class ShoppingCartController : Controller
    {
        private IShoppingCartService carts;
        private IProductService products;

        public ShoppingCartController(IShoppingCartService carts,
            IProductService products)
        {
            this.carts = carts;
            this.products = products;
        }

        public ActionResult Index(string returnUrl)
        {
            var cart = new ShoppingCartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };

            return View(cart);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(AddProductInputModel model, string returnUrl)
        {
            // TODO Code is repeated
            // TODO Destroy Session after user is logged in
            // TODO Require log in for the shopping cart to be seen
            string warningMessage = null;
            if (ModelState.IsValid)
            {
                var product = this.products.GetProdcutById(model.Id).FirstOrDefault();
                if (product != null)
                {
                    // TODO see how quantity will be taken
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
                        //TODO redirect with notification that product quantity is not enough to buy    
                        warningMessage = "Quantity is not enough to buy!";
                    }
                }
                else
                {
                    warningMessage = "Product does not exist!";
                }
            }

            this.TempData["Notification"] = warningMessage;
            return this.RedirectToAction("Details", "Products", new { area = string.Empty, id = model.Id });
        }

        public ActionResult RemoveFromCart(int productId, string returnUrl)
        {
            // TODO remove quantity
            GetCart().RemoveItem(productId);
            return RedirectToAction("Index", new { returnUrl });
        }

        private ShoppingCart GetCart()
        {
            var cart = (ShoppingCart)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}