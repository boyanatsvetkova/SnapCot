namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Linq;

    public interface IIndustryService
    {
        IQueryable<Industry> All();

        int Add(Industry industry);

        Industry GetById(int id);

        void Update(Industry industry, string name);

        void Dispose();
    }
}
