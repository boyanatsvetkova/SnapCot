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

    [Authorize]
    public class OrdersController : BaseController
    {
        private ITransportModeService transports;
        private IOrderService orders;

        public OrdersController(IUserService users, 
            ITransportModeService transports,
            IOrderService orders)
            : base(users)
        {
            this.transports = transports;
            this.orders = orders;
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            var user = this.CurrentUser;
            var cart = (ShoppingCart)Session["Cart"];
            var model = new MakeAnOrderViewModel
            {
                ShoppingCart = cart,
                TotalPrice = cart.GetCartTotal(),
                OrderDate = DateTime.UtcNow.ToShortDateString(),
                CreditLimit = (decimal)user.CreditLimit,
                Mode = this.GetTransportModes()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeOrder(MakeAnOrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var newOrder = new Order()
                {
                    OrderDate = Convert.ToDateTime(order.OrderDate),
                    ReceivedDate = Convert.ToDateTime(order.ReceivedDate),
                    ShoppingCart = order.ShoppingCart,
                    TotalPrice = order.TotalPrice,
                    TransportModeId = int.Parse(order.ModeId),
                    ShippingTerms = order.Terms,
                    UserId = this.CurrentUser.Id
                };

                this.orders.AddOrder(newOrder);
            }

            return Redirect("/");
        }

        private IEnumerable<SelectListItem> GetTransportModes()
        {
            var transportMode = this.transports
                .All()
                .Select(m => new SelectListItem()
                {
                    Text = m.Mode,
                    Value = m.Id.ToString()
                })
                .ToList();

            return transportMode;
        }
    }
}