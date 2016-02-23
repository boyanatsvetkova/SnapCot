namespace SnapCot.Web.Areas.SupplyManager.Controllers
{
    using Services.Contracts;
    using Infrastructure.Mapping;
    using System.Web.Mvc;
    using System.Linq;
    using ViewModels;
    using System;

    [Authorize]
    public class OrdersSupplyController : Controller
    {
        private IOrderService orders;

        public OrdersSupplyController(IOrderService orders)
        {
            this.orders = orders;
        }

        public ActionResult All(string sortOrder, int page = 1)
        {
            ViewBag.OrderDateSortParm = string.IsNullOrEmpty(sortOrder) ? "orderdate_desc" : "";
            ViewBag.ReceiveDateSortParm = sortOrder == "ReceiveDate" ? "receivedate_desc" : "ReceiveDate";
            var orders = this.orders.All();

            switch (sortOrder)
            {
                case "orderdate_desc":
                    orders = orders.OrderByDescending(p => p.OrderDate);
                    break;
                case "receivedate_desc":
                    orders = orders.OrderByDescending(p => p.ReceivedDate);
                    break;
                case "ReceiveDate":
                    orders = orders.OrderBy(p => p.ReceivedDate);
                    break;
                default:
                    orders = orders.OrderBy(p => p.OrderDate);
                    break;
            }

            var allorders = orders
                .Skip((page - 1) * 5)
                .Take(5)
                .To<OrderDetailsViewModel>()
                .ToList();
            var totalPages = (int)Math.Ceiling(orders.Count() / 5M);
            var model = new PageableOrdersViewModel
            {
                TotalPages = totalPages,
                CurrentPage = page,
                Orders = allorders,
                SortOrder = sortOrder
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var order = this.orders
                .GetOrderById(id)
                .To<OrderDetailsViewModel>()
                .FirstOrDefault();

            return View(order);
        }

        public ActionResult Approve(int id)
        {
            var order = this.orders.GetOrderById(id).FirstOrDefault();
            order.IsApproved = true;
            this.orders.UpdateOrder(order);

            return RedirectToAction("All");
        }
    }
}