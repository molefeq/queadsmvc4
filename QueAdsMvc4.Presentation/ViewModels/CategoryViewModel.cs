using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.SubCategories = new List<SubCategoryViewModel>();
        }
    
        public int? Id { get; set; }
        public string Name { get; set; }
        public int PolicyCount { get; set; }

        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}
