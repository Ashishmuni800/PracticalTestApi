using Application.DTO;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> EditEmployeeAsync(EmployeeDTO employee);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee);
        Task<IEnumerable<EmployeeDatatableViewModel>> GetEmployeeAsync();
        Task<EmployeeDatatableViewModel> GetEmployeeByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
