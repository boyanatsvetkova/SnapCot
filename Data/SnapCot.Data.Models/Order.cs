namespace SnapCot.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public bool IsApproved { get; set; }

        public ShippingTerms ShippingTerms { get; set; }

        public int? TransportModeId { get; set; }

        public TransportMode TransportMode { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string SupplyManagerId { get; set; }

        public virtual SupplyManager SupplyManager { get; set; }

        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
