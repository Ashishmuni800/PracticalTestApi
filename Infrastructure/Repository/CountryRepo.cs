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
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApiResponse _response;
        public CountryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Country> AddCountryAsync(Country Country)
        {
            _context.Country.Add(Country);
            await _context.SaveChangesAsync();
            return Country;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            var finddata = await _context.Country
                                          .Where(x => x.Id == Id && x.IsActive == true)
                                          .FirstOrDefaultAsync();

            // If found and it's active
            if (finddata != null)
            {
                // Set IsActive to false
                finddata.IsActive = false;

                // Update the entity in the context
                _context.Country.Update(finddata);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }

            return false;  // If no record was found, return false
        }

        public async Task<Country> EditCountryAsync(Country Country)
        {
            _context.Country.Update(Country);
            await _context.SaveChangesAsync();
            return Country;
        }

        public async Task<IEnumerable<Country>> GetCountryAsync()
        {
            return await _context.Country.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int Id)
        {
            return await _context.Country.Where(x => x.Id == Id && x.IsActive == true).FirstOrDefaultAsync();
        }
    }
}
