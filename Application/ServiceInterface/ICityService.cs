using Application.DTO;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface ICityService
    {
        Task<CityDTO> EditCityAsync(CityDTO City);
        Task<CityDTO> AddCityAsync(CityDTO City);
        Task<IEnumerable<CityViewModel>> GetCityAsync();
        Task<IEnumerable<CityViewModel>> GetCityByStateIdAsync(int StateId);
        Task<CityViewModel> GetCityByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
