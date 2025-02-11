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
    public class CityService : ICityService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public CityService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public Task<bool> AddCityAsync(CityDTO City)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCityAsync(CityDTO City)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityViewModel>> GetCityAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CityViewModel> GetCityByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
