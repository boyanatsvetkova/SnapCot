namespace SnapCot.Web.ViewModels.CommonViewModels
{
    using SnapCot.Data.Models;
    using SnapCot.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class IndustryViewModel : IMapFrom<Industry>
    {
        [Key]
        //[ScaffoldColumn(false)]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}