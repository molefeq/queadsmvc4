using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.ViewModels
{
    public class ProvinceViewModel
    {
        public ProvinceViewModel()
        {
            Cities = new List<CityViewModel>();
        }

        public int? Id { get; set; }
        public string Name { get; set; }

        public List<CityViewModel> Cities { get; set; }
    }
}
