using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApiResponse _response;
        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<City> AddCityAsync(City City)
        {
            _context.City.Add(City);
            await _context.SaveChangesAsync();
            return City;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            var finddata = _context.City.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (finddata != null)
            {
                _context.Remove(finddata);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<City> EditCityAsync(City City)
        {
            _context.City.Update(City);
            await _context.SaveChangesAsync();
            return City;
        }

        public async Task<IEnumerable<City>> GetCityAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int Id)
        {
            return await _context.City.Where(id => id.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetCityByStateIdAsync(int StateId)
        {
            return await _context.City.Where(Id => Id.StateId == StateId).ToListAsync();
        }
    }
}
