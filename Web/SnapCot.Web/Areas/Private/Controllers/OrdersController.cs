namespace SnapCot.Web.Areas.Private.Controllers
{
    using Services.Contracts;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;

    [Authorize]
    public class OrdersController : BaseController
    {
        private ITransportModeService transports;
        private IOrderService orders;
        private ICartItemService items;

        public OrdersController(IUserService users,
            ITransportModeService transports,
            IOrderService orders,
            ICartItemService items)
            : base(users)
        {
            this.transports = transports;
            this.orders = orders;
            this.items = items;
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            var user = this.CurrentUser;
            var model = new MakeAnOrderViewModel
            {
                TotalPrice = GetCart().GetCartTotal(),
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
                var cartProducts = GetCart().ProductCartItems;
                var newOrder = new Order()
                {
                    OrderDate = Convert.ToDateTime(order.OrderDate),
                    ReceivedDate = Convert.ToDateTime(order.ReceivedDate),
                    TotalPrice = order.TotalPrice,
                    TransportModeId = int.Parse(order.ModeId),
                    ShippingTerms = order.Terms,
                    UserId = this.CurrentUser.Id,
                    IsActive = true,
                    IsApproved = false
                };

                //newOrder.ProductCartItems = cartProducts;
                int id = this.orders.AddOrder(newOrder);
                var orderItems = new List<ProductCartItem>();
                foreach (var item in cartProducts)
                {
                    item.ProductId = item.Product.Id;
                    item.Product = null;
                    item.OrderId = id;
                    orderItems.Add(item);
                }

                this.items.Add(orderItems);
                GetCart().Clear();

                return Redirect("/");
            }

            order.Mode = this.GetTransportModes();
            return View(order);
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