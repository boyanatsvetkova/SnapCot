namespace SnapCot.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        private ICollection<ProductCartItem> products;

        public Order()
        {
            this.products = new HashSet<ProductCartItem>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsActive { get; set; }

        public ShippingTerms ShippingTerms { get; set; }

        public int? TransportModeId { get; set; }

        public TransportMode TransportMode { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        //public int? ShoppingCartId { get; set; }

        //public virtual ShoppingCart ShoppingCart { get; set; }

        public ICollection<ProductCartItem> ProductCartItems
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
