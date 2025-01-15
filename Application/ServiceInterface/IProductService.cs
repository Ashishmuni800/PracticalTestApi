using Application.DTO;
using Application.ViewModel;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IProductService
    {
        Task<ProductDTO> EditProductAsync(ProductDTO product);
        Task<ProductDTO> AddProductAsync(ProductDTO product);
        Task<IEnumerable<ProductViewModel>> GetProductAsync();
        Task<ProductViewModel> GetProductByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
