using QueAds.Common.DataTransformObjects;
using QueAds.Common.ResponseObjects;
using QueAds.Common.Utilities;

using QueAds.Service.Presentation.Factories;

using QueAdsMvc4.Presentation.DataTransformObjectMappers;
using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;
using QueAdsMvc4.Presentation.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class ProvinceServiceHandler : IProvinceHandler
    {
        public List<ProvinceViewModel> GetProvinces(string searchText)
        {
            Result<ProvinceDto> response = EntityFactory.ProvinceManager.GetProvinces(new SearchObject { SearchText = searchText });

            return response == null && response.Models == null && response.Models.Count == 0 ? new List<ProvinceViewModel>() : response.Models.Select(item => item.MapFromDto()).ToList();
        }
    }
}
