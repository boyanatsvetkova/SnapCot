namespace SnapCot.Web.Areas.Private.ViewModels
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class MakeAnOrderViewModel
    {
        [DisplayName("Total Price")]
        [Range(1.0, double.MaxValue, ErrorMessage = "You must buy a product to make an order!")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Order Date")]
        public string OrderDate { get; set; }

        [Required(ErrorMessage = "Order shipping date is required!")]
        [DisplayName("Received Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime? ReceivedDate { get; set; }

        [Required]
        [DisplayName("Shipping Terms")]
        public ShippingTerms Terms { get; set; }

        [Required(ErrorMessage = "Choose an order transport!")]
        [UIHint("TransportDropDown")]
        public string ModeId { get; set; }

        [DisplayName("Transport Mode")]
        public IEnumerable<SelectListItem> Mode { get; set; }

        [DisplayName("Credit Limit")]
        [Range(1.0, double.MaxValue, ErrorMessage = "Credit limit must be a positive number greater than 0!")]
        public decimal CreditLimit { get; set; }
    }
}