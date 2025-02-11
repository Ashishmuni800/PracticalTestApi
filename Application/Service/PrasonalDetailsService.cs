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
    public class PrasonalDetailsService : IPrasonalDetailsService
    {
        private readonly IServiceInfraRepo _Repo;
        private readonly IMapper _Mapp;

        public PrasonalDetailsService(IServiceInfraRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp = Mapp;
        }

        public Task<bool> AddPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletedAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PrasonalDetailsViewModel>> GetPrasonalDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PrasonalDetailsViewModel> GetPrasonalDetailsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
