namespace SnapCot.Data.DataSeed
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Linq;

    public class DataSeeder : IDataSeeder
    {
        const string AdminRole = "Admin";
        const string AdminName = "admin@gmail.com";

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
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));

            roleManager.Create(new IdentityRole() { Name = AdminRole });
            roleManager.Create(new IdentityRole() { Name = ManagerRole });
            this.context.SaveChanges();
        }

        public void SeedUsers()
        {
        //    if (this.context.Users.Any())
        //    {
        //        return;
        //    }

            var userManager = new UserManager<User>(new UserStore<User>(this.context));

            var adminUser = new User()
            {
                Email = AdminName,
                RegistrationDate = DateTime.Now,
                CreditLimit = 0,
                Telephone = "+359895177466",
                Address = "Sofia, bul. Alexandar Malinov",
                Name = "SnapCot",
                UserName = AdminName
            };

            var supplyManagerUser = new SupplyManager()
            {
                Email = ManagerName,
                RegistrationDate = DateTime.Now,
                CreditLimit = 0,
                Telephone = "+359895188499",
                Address = "Sofia, bul. Alexandar Malinov",
                Name = "SnapCot",
                UserName = ManagerName
            };

            var result = userManager.Create(adminUser, "123456");
            userManager.Create(supplyManagerUser, "654321");
            //this.context.SaveChanges();

            var admin = this.context.Users.FirstOrDefault(u => u.Email == AdminName);
            var manager = this.context.Users.FirstOrDefault(u => u.Email == ManagerName);

            userManager.AddToRole(admin.Id, AdminRole);
            userManager.AddToRole(manager.Id, ManagerRole);
        }
    }
}
