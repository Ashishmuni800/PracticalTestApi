using Application.DTO;
using Application.ServiceInterface;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _Repo;
        private readonly IMapper _Mapp;

        public EmployeeService(IEmployeeRepo Repo, IMapper Mapp)
        {
            _Repo = Repo;
            _Mapp=Mapp;
        }
        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employee)
        {
            var model= _Mapp.Map<Employee>(employee);
            await _Repo.AddEmployeeAsync(model).ConfigureAwait(false);
            _Repo.SaveChangesAsync();
            var dto=_Mapp.Map<EmployeeDTO>(model);
            return dto;

        }

        public async Task<bool> DeletedAsync(int Id)
        {
            return await _Repo.DeletedAsync(Id).ConfigureAwait(false);
        }

        public async Task<EmployeeDTO> EditEmployeeAsync(EmployeeDTO employee)
        {
            var model = _Mapp.Map<Employee>(employee);
            await _Repo.EditEmployeeAsync(model).ConfigureAwait(false);
            _Repo.SaveChangesAsync();
            var dto = _Mapp.Map<EmployeeDTO>(model);
            return dto;
        }

        public async Task<IEnumerable<EmployeeDatatableViewModel>> GetEmployeeAsync()
        {
            var model= await _Repo.GetEmployeeAsync().ConfigureAwait(false);
            var modelDto= _Mapp.Map<List<EmployeeDatatableViewModel>>(model);
            return (IEnumerable<EmployeeDatatableViewModel>)modelDto;
        }

        public async Task<EmployeeDatatableViewModel> GetEmployeeByIdAsync(int Id)
        {
            var model = await _Repo.GetEmployeeByIdAsync(Id).ConfigureAwait(false);
            var modelDto = _Mapp.Map<EmployeeDatatableViewModel>(model);
            return modelDto;
        }
    }
}
