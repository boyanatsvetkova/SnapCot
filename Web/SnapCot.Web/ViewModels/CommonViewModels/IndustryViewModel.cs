namespace SnapCot.Web.ViewModels.CommonViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;

    public class IndustryViewModel : IMapFrom<Industry>
    {
        public string Name { get; set; }
    }
}