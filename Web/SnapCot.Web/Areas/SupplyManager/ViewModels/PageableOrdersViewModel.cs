namespace SnapCot.Web.Areas.SupplyManager.ViewModels
{
    using System.Collections.Generic;

    public class PageableOrdersViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<OrderDetailsViewModel> Orders { get; set; }

        public string SortOrder { get; set; }

        public string SearchString { get; set; }
    }
}