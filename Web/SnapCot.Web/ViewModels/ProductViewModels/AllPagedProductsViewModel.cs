namespace SnapCot.Web.ViewModels.ProductViewModels
{
    using Paging;
    using ProducerViewModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using System;

    public class AllPagedProductsViewModel
    {
        public IList<AllProductsViewModel> Products { get; set; }

        public PaginationViewModel Pagination { get; set; }

        public int ProducerId { get; set; }

        public SelectList Producers { get; set; }

        public string Value { get; set; }

        public SelectList OrderByPrice { get; set; }

        public string SearchString { get; set; }
    }
}