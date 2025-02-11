using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext _employee;
        //private readonly ApiResponse _response;
        public CountryRepo(ApplicationDbContext context)
        {
            _employee = context;
        }

        public Task<bool> AddCountryAsync(Country Country)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCountryAsync(Country Country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetCountryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetCountryByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
