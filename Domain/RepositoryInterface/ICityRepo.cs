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
        Task<bool> EditCityAsync(City City);
        Task<bool> AddCityAsync(City City);
        Task<IEnumerable<City>> GetCityAsync();
        Task<City> GetCityByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
