namespace SnapCot.Web.Areas.Private.Controllers
{
    using Data.Models;
    using Services.Contracts;
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class BaseController : Controller
    {
        protected IUserService users;

        public BaseController(IUserService users)
        {
            this.users = users;
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.users
                .GetUser(requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }

        protected ShoppingCart GetCart()
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