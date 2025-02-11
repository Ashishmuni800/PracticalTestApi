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
    public class PrasonalDetailsRepo : IPrasonalDetailsRepo
    {
        private readonly ApplicationDbContext _employee;
        //private readonly ApiResponse _response;
        public PrasonalDetailsRepo(ApplicationDbContext context)
        {
            _employee = context;
        }
        public Task<bool> AddPrasonalDetailsAsync(PrasonalDetails prasonalDetails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPrasonalDetailsAsync(PrasonalDetails prasonalDetails)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetPrasonalDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetPrasonalDetailsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
