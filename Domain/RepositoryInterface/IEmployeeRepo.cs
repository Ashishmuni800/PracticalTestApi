using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IEmployeeRepo
    {
        Task<Employee> EditEmployeeAsync(Employee employee);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<IEnumerable<EmployeeDatatable>> GetEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int Id);
        void SaveChangesAsync();
    }
}
