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

        public async Task<PrasonalDetailsDTO> AddPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails)
        {
            var model = _Mapp.Map<PrasonalDetails>(PrasonalDetails);
            await _Repo.PrasonalDetailsRepo.AddPrasonalDetailsAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<PrasonalDetailsDTO>(model);
            return dto;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _Repo.PrasonalDetailsRepo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<PrasonalDetailsDTO> EditPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails)
        {
            var model = _Mapp.Map<PrasonalDetails>(PrasonalDetails);
            await _Repo.PrasonalDetailsRepo.EditPrasonalDetailsAsync(model).ConfigureAwait(false);
            _Repo.AuthRepo.SaveChangesAsync();
            var dto = _Mapp.Map<PrasonalDetailsDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<PrasonalDetailsViewModel>> GetPrasonalDetailsAsync()
        {
            var model = await _Repo.PrasonalDetailsRepo.GetPrasonalDetailsAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<PrasonalDetailsViewModel>>(model);
            return (IEnumerable<PrasonalDetailsViewModel>)modelDto;
        }

        public async Task<PrasonalDetailsViewModel> GetPrasonalDetailsByIdAsync(int Id)
        {
            var model = await _Repo.PrasonalDetailsRepo.GetPrasonalDetailsByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<PrasonalDetailsViewModel>(model);
            return modelDto;
        }
    }
}
