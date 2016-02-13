namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using Paging;
    using System.Collections.Generic;

    public class AllPagedProductsViewModel
    {
        public IList<AllProductsViewModel> Products { get; set; }

        public PaginationViewModel Pagination { get; set; }
    }
}