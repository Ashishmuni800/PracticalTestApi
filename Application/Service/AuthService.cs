using Application.DTO;
using Application.ServiceInterface;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;
        public AuthService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }
        public async Task<bool> DeletedAsync(string Id)
        {
            return await _Repo.AuthRepo.DeletedAsync(Id).ConfigureAwait(false);
        }
        public async Task<IEnumerable<AspNetUsersViewModel>> GetUserAsync()
        {
            var model = await _Repo.AuthRepo.GetUserAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<AspNetUsersViewModel>>(model);
            return (IEnumerable<AspNetUsersViewModel>)modelDto;
        }
        public async Task<AspNetUsersViewModel> GetUserByIdAsync(string Id)
        {
            var model = await _Repo.AuthRepo.GetUserByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<AspNetUsersViewModel>(model); 
            return modelDto;
        }
        public async Task<AspNetUsersDTO> LoginAsync(AspNetUsersDTO user)
        {
            var model = _Mapp.Map<AspNetUsers>(user);
            await _Repo.AuthRepo.LoginAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<AspNetUsersDTO>(model);
            return dto;
        }
        public async Task<AspNetUsersDTO> ResistrationAsync(AspNetUsersDTO user)
        {
            var model = _Mapp.Map<AspNetUsers>(user);
            await _Repo.AuthRepo.ResistrationAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<AspNetUsersDTO>(model);
            return dto;
        }
        public void SaveChangesAsync(CancellationToken cancellationToken)
        {
            _Repo.AuthRepo.SaveChangesAsync(cancellationToken);
        }
        public async Task<AspNetUsersDTO> UpdateAsync(AspNetUsersDTO user)
        {
            var model = _Mapp.Map<AspNetUsers>(user);
            await _Repo.AuthRepo.UpdateAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<AspNetUsersDTO>(model);
            return dto;
        }
        public async Task<AspNetUsersDTO> GetUserByEmailAsync(string email)
        {
            var model = await _Repo.AuthRepo.GetUserByEmailAsync(email).ConfigureAwait(false);
            var modelDto = _Mapp.Map<AspNetUsersDTO>(model);
            return modelDto;
        }

        public async Task<RefreshTokenDTO> AddRefreshTokensAsync(RefreshTokenDTO refreshToken)
        {
            var model = _Mapp.Map<RefreshToken>(refreshToken);
            await _Repo.AuthRepo.AddRefreshTokensAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<RefreshTokenDTO>(model);
            return dto;
        }

        public void SaveChangesAsync()
        {
             _Repo.AuthRepo.SaveChangesAsync();
        }
    }
}
