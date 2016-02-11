namespace SnapCot.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<ShoppingCart> shoppingCarts;
        private ICollection<Order> orders;
        private ICollection<Comment> comments;

        public User()
        {
            this.shoppingCarts = new HashSet<ShoppingCart>();
            this.orders = new HashSet<Order>();
            this.comments = new HashSet<Comment>();
        }

        public string Avatar { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public decimal? CreditLimit { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 80)]
        public string Adress { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get { return this.shoppingCarts; }
            set { this.shoppingCarts = value; }
        }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
