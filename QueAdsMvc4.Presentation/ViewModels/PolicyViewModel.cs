using QueAdsMvc4.Presentation.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class PolicyViewModel
    {
        public PolicyViewModel()
        {
            Category = new CategoryViewModel();
            SubCategory = new SubCategoryViewModel();
            Province = new ProvinceViewModel();
            City = new CityViewModel();
            CreateUser = new UserViewModel();
            PolicyImages = new List<PolicyImageViewModel>();
            PolicySubCategoryAdditionalFields = new List<PolicySubCategoryAdditionalFieldViewModel>();
        }

        public int? Id { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]
        public CategoryViewModel Category { get; set; }

        [Display(Name = "Sub Category")]
        [Required(ErrorMessage = "sub Category is required.")]
        public SubCategoryViewModel SubCategory { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required.")]
        public ProvinceViewModel Province { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public CityViewModel City { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Subject { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Display(Name = "Offer Type")]
        public string OfferType { get; set; }

        [Display(Name = "Price (In Rands)")]
        [RegularExpression(@"^([0-9]{1,10}|[0-9]{1,10}\.[0-9]{1,2})$", ErrorMessage = "Invalid Price, the value must match the following format 9.32, 89.23, 1000.23, 9 with maximum value of 99999999.99.")]
        public string Price { get; set; }

        [Display(Name = "Negotiable?")]
        public bool NegotiableInd { get; set; }

        [Display(Name = "Images")]
        public List<PolicyImageViewModel> PolicyImages { get; set; }

        [Display(Name = "Additional Fields")]
        public List<PolicySubCategoryAdditionalFieldViewModel> PolicySubCategoryAdditionalFields { get; set; }

        [Display(Name = "Create User")]
        public UserViewModel CreateUser { get; set; }

        [Display(Name = "Register User")]
        public RegisterUserViewModel RegisterUser { get; set; }

        public int? CreateUserId { get; set; }

        //[Display(Name = "Create Date")]
        //public DateTime? CreateDate { get; set; }

        [Display(Name = "Create Date")]
        public string CreateDateText { get; set; }

        //[Display(Name = "Edit tDate")]
        //public DateTime? EditDate { get; set; }

        [Display(Name = "Edit tDate")]
        public string EditDateText { get; set; }

        public bool IsAuthenticated { get; set; }
        public CrudOperation CrudOperation { get; set; }
    }
}
