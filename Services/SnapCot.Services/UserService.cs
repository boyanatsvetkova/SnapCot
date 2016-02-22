namespace SnapCot.Services
{
    using SnapCot.Data.Models;
    using SnapCot.Data.Repositories;
    using Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        private IRepository<User> users;
        private IRepository<SupplyManager> managers;

        public UserService(IRepository<User> users, IRepository<SupplyManager> managers)
        {
            this.users = users;
            this.managers = managers;
        }

        public User GetUser(string name)
        {
            return this.users
                 .All()
                 .Where(u => u.UserName == name)
                 .FirstOrDefault();
        }

        public SupplyManager GetManager()
        {
            return this.managers.All().Where(u => u.UserName == "snapcotmag@snap.com").FirstOrDefault();
        }
    }
}
