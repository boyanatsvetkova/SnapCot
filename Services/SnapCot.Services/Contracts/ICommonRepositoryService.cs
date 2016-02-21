namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Linq;

    public interface ICommonRepositoryService
    {
        IQueryable<HazardClassification> AllClassifications();

        IQueryable<Industry> AllIndustries();
    }
}
