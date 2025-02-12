using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IStateRepo
    {
        Task<State> EditStateAsync(State State);
        Task<State> AddStateAsync(State State);
        Task<IEnumerable<State>> GetStateAsync();
        Task<IEnumerable<State>> GetStateByCountryIdAsync(int CountryId);
        Task<State> GetStateByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
