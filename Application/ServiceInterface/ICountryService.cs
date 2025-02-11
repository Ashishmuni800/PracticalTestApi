using Application.DTO;
using Application.ViewModel;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface ICountryService
    {
        Task<bool> EditCountryAsync(CountryDTO Country);
        Task<bool> AddCountryAsync(CountryDTO Country);
        Task<IEnumerable<CountryViewModel>> GetCountryAsync();
        Task<CountryViewModel> GetCountryByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
