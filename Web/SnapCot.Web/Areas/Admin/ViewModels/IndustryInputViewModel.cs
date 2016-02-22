namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;

    public class IndustryInputViewModel : IMapFrom<Industry>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}