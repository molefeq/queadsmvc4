using System.ComponentModel.DataAnnotations;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class PolicyReplyViewModel
    {
        [Display(Name = "PolicyId")]
        [Required(ErrorMessage = "PolicyId is required.")]
        public int? Policy_Id { get; set; }

        public string Policy_Create_User { get; set; }
        public string Policy_Create_EmailAddress { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Subject { get; set; }
        
        [Display(Name = "Email Address*")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(200, ErrorMessage = "Mobile Number cannot be more than 200 characters.")]
        public string EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(20, ErrorMessage = "Phone Number cannot be more than 20 characters.")]
        [RegularExpression("^(\\+27[0-9]{9})|(0[0-9]{9})*$", ErrorMessage = "Landline can either be like 0114475236 or +27111234567")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Name")]
        [StringLength(200, ErrorMessage = "Name cannot be more than 200 characters.")]
        public string Name { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
