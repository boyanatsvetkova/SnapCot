namespace SnapCot.Data.Migrations
{
    using DataSeed;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SnapCotDbContext>
    {
        const string AdminRole = "Admin";
        const string AdminName = "admin@gmail.com";

        const string ManagerRole = "SupplyManager";
        const string ManagerName = "snapcotmag@snap.com";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SnapCotDbContext context)
        {
            var seed = new DataSeeder(context);
            seed.SeedRoles();
            seed.SeedUsers();
            seed.SeedData();
        }
    }
}
