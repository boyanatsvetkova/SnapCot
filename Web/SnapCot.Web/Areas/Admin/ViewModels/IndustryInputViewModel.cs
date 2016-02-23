namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class IndustryInputViewModel : IMapFrom<Industry>
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}