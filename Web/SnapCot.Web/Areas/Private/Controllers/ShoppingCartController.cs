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
        public ActionResult AddToCart(int id, string returnUrl)
        {
            var product = this.products.GetProdcutById(id).FirstOrDefault();

            if (product != null)
            {
                // TODO see how quantity will be taken
                //if (product.Quantity > quantity)
                //{
                //this.products.UpdateProductQuantity(product, 0);
                this.GetCart().AddItem(product, 0);
                //}

                //TODO redirect with notification that product quantity is not enough to buy               
            }

            return RedirectToAction("Index", new { returnUrl });
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