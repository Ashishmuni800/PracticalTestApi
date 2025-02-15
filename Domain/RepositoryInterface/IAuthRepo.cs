using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IAuthRepo
    {
        Task<AspNetUsers> ResistrationAsync(AspNetUsers user);
        Task<RefreshToken> AddRefreshTokensAsync(RefreshToken refreshToken);
        Task<AspNetUsers> LoginAsync(AspNetUsers user);
        Task<AspNetUsers> UpdateAsync(AspNetUsers user);
        Task<IEnumerable<AspNetUsers>> GetUserAsync();
        Task<AspNetUsers> GetUserByIdAsync(string Id);
        Task<bool> DeletedAsync(string Id);
        void SaveChangesAsync();
        void SaveChangesAsync(CancellationToken cancellationToken);
        Task<AspNetUsers> GetUserByEmailAsync(string email);
    }
}
