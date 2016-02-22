namespace SnapCot.Web.Areas.Admin.ViewModels
{
    using Web.ViewModels.CommonViewModels;
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
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|
2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|
4[987654310]|3[9643210]|2[70]|7|1)\d{1,14}$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        public CountryDropDownViewModel Country { get; set; }
    }
}