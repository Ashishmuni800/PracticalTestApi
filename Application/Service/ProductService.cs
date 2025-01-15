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
    public class ProductService : IProductService
    {
        private readonly IProductRepo _IProductRepo;
        private readonly IMapper _Mapp;
        public ProductService(IProductRepo IProductRepo, IMapper Mapp)
        {
            _IProductRepo = IProductRepo;
            _Mapp = Mapp;
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO product)
        {
            var model = _Mapp.Map<Product>(product);
            await _IProductRepo.AddProductAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<ProductDTO>(model);
            return dto;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _IProductRepo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<ProductDTO> EditProductAsync(ProductDTO product)
        {
            var model = _Mapp.Map<Product>(product);
            await _IProductRepo.EditProductAsync(model).ConfigureAwait(false);
            var dto = _Mapp.Map<ProductDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductAsync()
        {
            var model = await _IProductRepo.GetProductAsync().ConfigureAwait(false);
            var modelDto = _Mapp.Map<List<ProductViewModel>>(model);
            return modelDto;
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int Id)
        {
            var model = await _IProductRepo.GetProductByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<ProductViewModel>(model);
            return modelDto;
        }
    }
}
