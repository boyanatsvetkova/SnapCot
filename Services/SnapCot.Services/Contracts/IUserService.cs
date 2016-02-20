namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;

    public interface IUserService
    {
        User GetUser(string name);
    }
}
