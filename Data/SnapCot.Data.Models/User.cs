namespace SnapCot.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
