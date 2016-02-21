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
        public ShoppingCart ShoppingCart { get; set; }

        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Order Date")]
        public string OrderDate { get; set; }

        [Required]
        [DisplayName("Received Date")]
        [DataType(DataType.Date)]
        public DateTime? ReceivedDate { get; set; }

        [DisplayName("Shipping Terms")]
        public ShippingTerms Terms { get; set; }

        [UIHint("TransportDropDown")]
        public string ModeId { get; set; }

        [DisplayName("Transport Mode")]
        public IEnumerable<SelectListItem> Mode { get; set; }

        [DisplayName("Credit Limit")]
        public decimal CreditLimit { get; set; }
    }
}