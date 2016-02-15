namespace SnapCot.Web.ViewModels.ProducerViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;

    public class ProducerViewModel : IMapFrom<Producer>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}