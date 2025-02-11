using Application.DTO;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IStateService
    {
        Task<bool> EditStateAsync(StateDTO State);
        Task<bool> AddStateAsync(StateDTO State);
        Task<IEnumerable<StateViewModel>> GetStateAsync();
        Task<StateViewModel> GetStateByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
