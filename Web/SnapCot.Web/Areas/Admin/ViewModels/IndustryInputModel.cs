namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class IndustryInputModel
    {
        //[ScaffoldColumn(false)]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}