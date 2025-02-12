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
        Task<Country> EditCountryAsync(Country Country);
        Task<Country> AddCountryAsync(Country Country);
        Task<IEnumerable<Country>> GetCountryAsync();
        Task<Country> GetCountryByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
