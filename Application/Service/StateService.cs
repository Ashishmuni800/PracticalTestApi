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
    public class StateService : IStateService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public StateService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public async Task<StateDTO> AddStateAsync(StateDTO State)
        {
            var model = _Mapp.Map<State>(State);
            await _Repo.StateRepo.AddStateAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<StateDTO>(model);
            return dto;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _Repo.StateRepo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<StateDTO> EditStateAsync(StateDTO State)
        {
            var model = _Mapp.Map<State>(State);
            await _Repo.StateRepo.EditStateAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<StateDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<StateViewModel>> GetStateAsync()
        {
            var model = await _Repo.StateRepo.GetStateAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<StateViewModel>>(model);
            return modelDto;
        }

        public async Task<IEnumerable<StateViewModel>> GetStateByCountryIdAsync(int CountryId)
        {
            var model = await _Repo.StateRepo.GetStateByCountryIdAsync(CountryId).ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<StateViewModel>>(model);
            return modelDto;
        }

        public async Task<StateViewModel> GetStateByIdAsync(int Id)
        {
            var model = await _Repo.StateRepo.GetStateByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<StateViewModel>(model);
            return modelDto;
        }
    }
}
