using Application.DTO;
using Application.ViewModel;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IAuthService
    {
        Task<AspNetUsersDTO> ResistrationAsync(AspNetUsersDTO user);
        Task<AspNetUsersDTO> LoginAsync(AspNetUsersDTO user);
        Task<AspNetUsersDTO> UpdateAsync(AspNetUsersDTO user);
        Task<IEnumerable<AspNetUsersViewModel>> GetUserAsync();
        Task<AspNetUsersViewModel> GetUserByIdAsync(string Id);
        Task<bool> DeletedAsync(string Id);
        void SaveChangesAsync();
    }
}
