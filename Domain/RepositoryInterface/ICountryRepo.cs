using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface ICountryRepo
    {
        Task<bool> EditCountryAsync(Country Country);
        Task<bool> AddCountryAsync(Country Country);
        Task<IEnumerable<Country>> GetCountryAsync();
        Task<Country> GetCountryByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
