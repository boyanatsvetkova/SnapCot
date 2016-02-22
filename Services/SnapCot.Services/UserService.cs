namespace SnapCot.Services
{
    using SnapCot.Data.Models;
    using SnapCot.Data.Repositories;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;

    public class UserService : IUserService
    {
        private IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetUser(string name)
        {
            return this.users
                 .All()
                 .Where(u => u.UserName == name)
                 .FirstOrDefault();
        }
    }
}
