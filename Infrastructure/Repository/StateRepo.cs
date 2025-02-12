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
            var finddata = _context.State.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (finddata != null)
            {
                _context.Remove(finddata);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<State> EditStateAsync(State State)
        {
            _context.State.Update(State);
            await _context.SaveChangesAsync();
            return State;
        }

        public async Task<IEnumerable<State>> GetStateAsync()
        {
            return await _context.State.ToListAsync();
        }

        public async Task<IEnumerable<State>> GetStateByCountryIdAsync(int CountryId)
        {
            return await _context.State.Where(Id=>Id.CountryId==CountryId).ToListAsync();
        }

        public async Task<State> GetStateByIdAsync(int Id)
        {
            return await _context.State.Where(id => id.Id == Id).FirstOrDefaultAsync();
        }
    }
}
