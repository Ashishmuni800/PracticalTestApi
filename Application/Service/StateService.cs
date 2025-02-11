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
    public class StateService : IStateService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public StateService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public Task<bool> AddStateAsync(StateDTO State)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditStateAsync(StateDTO State)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StateViewModel>> GetStateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StateViewModel> GetStateByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
