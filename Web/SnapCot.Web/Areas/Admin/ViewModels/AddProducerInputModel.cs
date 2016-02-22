namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AddProducerInputModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Website { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [UIHint("CountryDropDown")]
        public string CountryId { get; set; }

        //public IEnumerable<SelectListItem> Country { get; set; }
    }
}