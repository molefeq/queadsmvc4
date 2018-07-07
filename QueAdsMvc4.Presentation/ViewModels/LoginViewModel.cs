using System.ComponentModel.DataAnnotations;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Username*")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Display(Name = "Password*")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
