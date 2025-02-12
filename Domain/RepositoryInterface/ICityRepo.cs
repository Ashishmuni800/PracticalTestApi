using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface ICityRepo
    {
        Task<City> EditCityAsync(City City);
        Task<City> AddCityAsync(City City);
        Task<IEnumerable<City>> GetCityAsync();
        Task<IEnumerable<City>> GetCityByStateIdAsync(int StateId);
        Task<City> GetCityByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
