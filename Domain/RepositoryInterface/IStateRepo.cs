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
        Task<bool> EditStateAsync(State State);
        Task<bool> AddStateAsync(State State);
        Task<IEnumerable<State>> GetStateAsync();
        Task<State> GetStateByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
