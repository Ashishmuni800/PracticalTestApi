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
    public class PrasonalDetailsRepo : IPrasonalDetailsRepo
    {
        private readonly ApplicationDbContext _context;
        //private readonly ApiResponse _response;
        public PrasonalDetailsRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PrasonalDetails> AddPrasonalDetailsAsync(PrasonalDetails prasonalDetails)
        {
            await _context.PrasonalDetails.AddAsync(prasonalDetails);
            await _context.SaveChangesAsync();
            return prasonalDetails;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            var finddata = _context.PrasonalDetails.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (finddata != null) 
            {
                _context.Remove(finddata);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<PrasonalDetails> EditPrasonalDetailsAsync(PrasonalDetails prasonalDetails)
        {
             _context.PrasonalDetails.Update(prasonalDetails);
            await _context.SaveChangesAsync();
            return prasonalDetails;
        }

        public async Task<IEnumerable<PrasonalDetailsDataModel>> GetPrasonalDetailsAsync()
        {
            List<PrasonalDetailsDataModel> prasonals = await(from c in _context.Country
                                                             join p in _context.PrasonalDetails on c.Id equals p.CountryId
                                                             join s in _context.State on c.Id equals s.CountryId
                                                             join ci in _context.City on s.Id equals ci.StateId
                                                             select new PrasonalDetailsDataModel
                                                             {
                                                                 Id = p.Id,
                                                                 Name = p.Name,
                                                                 Email = p.Email,
                                                                 Phone = p.Phone,
                                                                 Address = p.Address,
                                                                 CountryName = c.CountryName,
                                                                 StateName = s.StateName,
                                                                 CityName = ci.CityName
                                                             }).ToListAsync();
            return prasonals;
        }

        public async Task<PrasonalDetailsDataModel> GetPrasonalDetailsByIdAsync(int Id)
        {
            var prasonal = await (from c in _context.Country
                                  join p in _context.PrasonalDetails on c.Id equals p.CountryId
                                  join s in _context.State on c.Id equals s.CountryId
                                  join ci in _context.City on s.Id equals ci.StateId
                                  where p.Id == Id
                                  select new PrasonalDetailsDataModel
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Email = p.Email,
                                      Phone = p.Phone,
                                      Address = p.Address,
                                      CountryName = c.CountryName,
                                      StateName = s.StateName,
                                      CityName = ci.CityName
                                  }).FirstOrDefaultAsync();

            return prasonal;
        }

    }
}
