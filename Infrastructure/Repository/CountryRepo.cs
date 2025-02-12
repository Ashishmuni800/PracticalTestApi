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
            var finddata = _context.Country.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (finddata != null)
            {
                _context.Remove(finddata);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Country> EditCountryAsync(Country Country)
        {
            _context.Country.Update(Country);
            await _context.SaveChangesAsync();
            return Country;
        }

        public async Task<IEnumerable<Country>> GetCountryAsync()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int Id)
        {
            return await _context.Country.Where(id => id.Id == Id).FirstOrDefaultAsync();
        }
    }
}
