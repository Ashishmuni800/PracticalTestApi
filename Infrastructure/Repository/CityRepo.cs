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
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _employee;
        //private readonly ApiResponse _response;
        public CityRepo(ApplicationDbContext context)
        {
            _employee = context;
        }

        public Task<bool> AddCityAsync(City City)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCityAsync(City City)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> GetCityAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetCityByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
