using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IPrasonalDetailsRepo
    {
        Task<bool> EditPrasonalDetailsAsync(PrasonalDetails prasonalDetails);
        Task<bool> AddPrasonalDetailsAsync(PrasonalDetails prasonalDetails);
        Task<IEnumerable<Product>> GetPrasonalDetailsAsync();
        Task<Product> GetPrasonalDetailsByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
