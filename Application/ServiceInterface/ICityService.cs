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
        Task<bool> EditCityAsync(CityDTO City);
        Task<bool> AddCityAsync(CityDTO City);
        Task<IEnumerable<CityViewModel>> GetCityAsync();
        Task<CityViewModel> GetCityByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
