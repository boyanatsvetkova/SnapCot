namespace SnapCot.Services.Contracts
{
    using SnapCot.Data.Models;
    using System.Linq;

    public interface IProducerService
    {
        IQueryable<Producer> All();

        void Add(Producer producer);

        IQueryable<Producer> GetProducers();
    }
}
