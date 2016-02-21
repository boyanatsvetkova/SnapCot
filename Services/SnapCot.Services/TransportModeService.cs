namespace SnapCot.Services
{
    using SnapCot.Data.Models;
    using Data.Repositories;
    using System.Linq;
    using Contracts;

    public class TransportModeService : ITransportModeService
    {
        private IRepository<TransportMode> transports;

        public TransportModeService(IRepository<TransportMode> transports)
        {
            this.transports = transports;
        }

        public IQueryable<TransportMode> All()
        {
            return this.transports
                .All();
        }
    }
}
