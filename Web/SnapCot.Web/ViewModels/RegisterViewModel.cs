namespace SnapCot.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel 
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Company name")]
        [StringLength(50, ErrorMessage = "The Company name must be between 2 and 50 characters long", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "The {0} must be between 2 and 80 characters long", MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between 10 and 20 digits long", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "The {0} must be from $0 to $1 000 000 ")]
        public decimal CreditLimit { get; set; }

        [Display(Name = "Country")]
        public string CountryId { get; set; }
    }
}