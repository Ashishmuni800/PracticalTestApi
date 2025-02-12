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
        Task<PrasonalDetails> EditPrasonalDetailsAsync(PrasonalDetails prasonalDetails);
        Task<PrasonalDetails> AddPrasonalDetailsAsync(PrasonalDetails prasonalDetails);
        Task<IEnumerable<PrasonalDetailsDataModel>> GetPrasonalDetailsAsync();
        Task<PrasonalDetailsDataModel> GetPrasonalDetailsByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
