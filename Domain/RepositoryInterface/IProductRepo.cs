using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IProductRepo
    {
        Task<bool> EditProductAsync(Product product);
        Task<bool> AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
