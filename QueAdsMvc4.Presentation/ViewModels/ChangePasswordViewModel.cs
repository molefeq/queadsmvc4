using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Username*")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; }

        [Display(Name = "Password*")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Display(Name = "New Password*")]
        [Required(ErrorMessage = "New Password is required.")]
        [StringLength(50, ErrorMessage = "New Password cannot be more than 50 characters.")]
        [RegularExpression("^([a-zA-Z0-9]{3,50})*$", ErrorMessage = "New Password must only be character or numbers of atleast 3 characters.")]
        public string NewPassword { get; set; }
    }
}
