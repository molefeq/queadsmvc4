using System.ComponentModel.DataAnnotations;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class RegisterUserViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Firstnames*")]
        [Required(ErrorMessage = "Firstnames is required.")]
        [StringLength(200, ErrorMessage = "Firstnames cannot be more than 200 characters.")]
        public string Firstnames { get; set; }

        [Display(Name = "Lastname*")]
        [Required(ErrorMessage = "Lastname is required.")]
        [StringLength(100, ErrorMessage = "Lastname cannot be more than 100 characters.")]
        public string Lastname { get; set; }

        [Display(Name = "Username*")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be more than 50 characters.")]
        [RegularExpression("^([a-zA-Z0-9]{3,50})*$", ErrorMessage = "Username must only be character or numbers of atleast 3 characters.")]
        public string UserName { get; set; }

        [Display(Name = "Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Password cannot be more than 50 characters.")]
        [RegularExpression("^([a-zA-Z0-9]{3,50})*$", ErrorMessage = "Password must only be character or numbers of atleast 3 characters.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password*")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [StringLength(50, ErrorMessage = "Confirm Password cannot be more than 50 characters.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email Address*")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(200, ErrorMessage = "Mobile Number cannot be more than 200 characters.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Mobile Number")]
        [StringLength(20, ErrorMessage = "Mobile Number cannot be more than 20 characters.")]
        public string MobileNumber { get; set; }
    }
}
