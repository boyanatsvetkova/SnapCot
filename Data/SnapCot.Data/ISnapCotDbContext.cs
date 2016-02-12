namespace SnapCot.Data
{
    using SnapCot.Data.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ISnapCotDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<HazardClassification> HazardClassifications { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Industry> Industries { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Producer> Producers { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<ProductCartItem> ProductCartItems { get; set; }

        IDbSet<ShoppingCart> ShoppingCart { get; set; }

        //IDbSet<SupplyManager> SupplyManagers { get; set; }

        IDbSet<TransportMode> TransportModes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
