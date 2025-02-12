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
            var finddata = await _context.City
                                          .Where(x => x.Id == Id && x.IsActive == true)
                                          .FirstOrDefaultAsync();

            // If found and it's active
            if (finddata != null)
            {
                // Set IsActive to false
                finddata.IsActive = false;

                // Update the entity in the context
                _context.City.Update(finddata);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }

            return false;  // If no record was found, return false
        }

        public async Task<City> EditCityAsync(City City)
        {
            _context.City.Update(City);
            await _context.SaveChangesAsync();
            return City;
        }

        public async Task<IEnumerable<City>> GetCityAsync()
        {
            return await _context.City.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int Id)
        {
            return await _context.City.Where(x => x.Id == Id && x.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetCityByStateIdAsync(int StateId)
        {
            return await _context.City.Where(x => x.StateId == StateId && x.IsActive == true).ToListAsync();
        }
    }
}
