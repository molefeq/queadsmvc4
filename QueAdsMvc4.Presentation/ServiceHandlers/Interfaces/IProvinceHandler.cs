using QueAdsMvc4.Presentation.ViewModels;
using System.Collections.Generic;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Interfaces
{
    public interface IProvinceHandler
    {
        List<ProvinceViewModel> GetProvinces(string searchText);
    }
}
