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
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApiResponse _response;
        public StateRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<State> AddStateAsync(State State)
        {
            _context.State.Add(State);
            await _context.SaveChangesAsync();
            return State;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            var finddata = await _context.State
                                          .Where(x => x.Id == Id && x.IsActive == true)
                                          .FirstOrDefaultAsync();

            // If found and it's active
            if (finddata != null)
            {
                // Set IsActive to false
                finddata.IsActive = false;

                // Update the entity in the context
                _context.State.Update(finddata);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }

            return false;  // If no record was found, return false
        }

        public async Task<State> EditStateAsync(State State)
        {
            _context.State.Update(State);
            await _context.SaveChangesAsync();
            return State;
        }

        public async Task<IEnumerable<State>> GetStateAsync()
        {
            return await _context.State.Where(x=>x.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<State>> GetStateByCountryIdAsync(int CountryId)
        {
            return await _context.State.Where(x=>x.CountryId==CountryId && x.IsActive == true).ToListAsync();
        }

        public async Task<State> GetStateByIdAsync(int Id)
        {
            return await _context.State.Where(x => x.Id == Id && x.IsActive == true).FirstOrDefaultAsync();
        }
    }
}
