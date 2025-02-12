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
    public class CountryService : ICountryService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public CountryService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public async Task<CountryDTO> AddCountryAsync(CountryDTO Country)
        {
            var model = _Mapp.Map<Country>(Country);
            await _Repo.CountryRepo.AddCountryAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<CountryDTO>(model);
            return dto;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _Repo.CountryRepo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<CountryDTO> EditCountryAsync(CountryDTO Country)
        {
            var model = _Mapp.Map<Country>(Country);
            await _Repo.CountryRepo.EditCountryAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<CountryDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountryAsync()
        {
            var model = await _Repo.CountryRepo.GetCountryAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<CountryViewModel>>(model);
            return modelDto;
        }

        public async Task<CountryViewModel> GetCountryByIdAsync(int Id)
        {
            var model = await _Repo.CountryRepo.GetCountryByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<CountryViewModel>(model);
            return modelDto;
        }
    }
}
