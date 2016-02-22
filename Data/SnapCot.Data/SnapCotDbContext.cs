namespace SnapCot.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repositories;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SnapCotDbContext : IdentityDbContext<User>, ISnapCotDbContext
    {    
        public SnapCotDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SnapCotDbContext Create()
        {
            return new SnapCotDbContext();
        }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual  IDbSet<Country> Countries { get; set; }
   
        public virtual  IDbSet<HazardClassification> HazardClassifications { get; set; }
         
        public virtual  IDbSet<Image> Images { get; set; }
     
        public virtual  IDbSet<Industry> Industries { get; set; }
          
        public virtual  IDbSet<Order> Orders { get; set; }
             
        public virtual  IDbSet<Producer> Producers { get; set; }
           
        public virtual  IDbSet<Product> Products { get; set; }
            
        public virtual  IDbSet<ProductCartItem> ProductCartItems { get; set; }
            
        public virtual  IDbSet<ShoppingCart> ShoppingCart { get; set; }

        public virtual IDbSet<SupplyManager> SupplyManagers { get; set; }

        public virtual IDbSet<TransportMode> TransportModes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ShoppingCart>()
            //     .HasRequired(x => x.Order).WithMany()
            //     .HasForeignKey(x => x.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
