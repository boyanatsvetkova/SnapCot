namespace SnapCot.Web.ViewModels.CommonViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CountryDropDownViewModel
    {
        [Required(ErrorMessage = "Country is required")]
        [UIHint("CountryDropDown")]
        public string CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}