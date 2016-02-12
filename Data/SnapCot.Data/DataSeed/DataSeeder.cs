namespace SnapCot.Data.DataSeed
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;

    public class DataSeeder : IDataSeeder
    {
        const string AdminRole = "Admin";
        const string AdminName = "snapcotadmin@snap.com";

        const string ManagerRole = "SupplyManager";
        const string ManagerName = "snapcotmag@snap.com";

        private SnapCotDbContext context; 

        public DataSeeder(SnapCotDbContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            
        }

        public void SeedRoles()
        {

            var userManager = new UserManager<User>(new UserStore<User>(this.context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

            roleManager.Create(new IdentityRole() { Name = AdminRole });
            roleManager.Create(new IdentityRole() { Name = ManagerRole });

            
        }
    }
}
