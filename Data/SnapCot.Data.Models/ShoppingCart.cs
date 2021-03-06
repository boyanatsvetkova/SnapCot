﻿namespace SnapCot.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class ShoppingCart
    {
        private ICollection<ProductCartItem> productCartItems;

        public ShoppingCart()
        {
            this.productCartItems = new HashSet<ProductCartItem>();
        }

        [Key]
        public int Id { get; set; }

        //public string UserId { get; set; }

        //public virtual User User { get; set; }

        //public int OrderId { get; set; }

        //public virtual Order Order { get; set; }

        public ICollection<ProductCartItem> ProductCartItems
        {
            get { return this.productCartItems; }
            set { this.productCartItems = value; }
        }
    }

  
}
