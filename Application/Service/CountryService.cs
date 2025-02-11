using Application.DTO;
using Application.ServiceInterface;
using Application.ViewModel;
using AutoMapper;
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

        public Task<bool> AddCountryAsync(CountryDTO Country)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCountryAsync(CountryDTO Country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryViewModel>> GetCountryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CountryViewModel> GetCountryByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
