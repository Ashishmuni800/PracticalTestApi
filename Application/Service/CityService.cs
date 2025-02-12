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
    public class CityService : ICityService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public CityService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public async Task<CityDTO> AddCityAsync(CityDTO City)
        {
            var model = _Mapp.Map<City>(City);
            await _Repo.CityRepo.AddCityAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<CityDTO>(model);
            return dto;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _Repo.CityRepo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<CityDTO> EditCityAsync(CityDTO City)
        {
            var model = _Mapp.Map<City>(City);
            await _Repo.CityRepo.EditCityAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<CityDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<CityViewModel>> GetCityAsync()
        {
            var model = await _Repo.CityRepo.GetCityAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<CityViewModel>>(model);
            return modelDto;
        }

        public async Task<CityViewModel> GetCityByIdAsync(int Id)
        {
            var model = await _Repo.CityRepo.GetCityByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<CityViewModel>(model);
            return modelDto;
        }

        public async Task<IEnumerable<CityViewModel>> GetCityByStateIdAsync(int StateId)
        {
            var model = await _Repo.CityRepo.GetCityByStateIdAsync(StateId).ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<CityViewModel>>(model);
            return modelDto;
        }
    }
}
