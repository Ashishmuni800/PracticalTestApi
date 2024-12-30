using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly ApplicationDbContext _employee;
        public EmployeeRepo(ApplicationDbContext context)
        {
            _employee = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            // Calculate the allowances and deductions
            var dearnessAllowance = employee.BasicSalary * 0.40f;
            var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
            var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);

            var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;

            // Calculate PT based on GrossSalary
            int pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;

            var totalSalary = grossSalary - pt;

            // Save the employee details to the database
            await _employee.Employee.AddAsync(employee);
            await _employee.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            var remo=await _employee.Employee.Where(ep => ep.Id == Id).SingleOrDefaultAsync();
            _employee.Employee.Remove(remo);
            await _employee.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> EditEmployeeAsync(Employee employee)
        {
            // Calculate the allowances and deductions
            var dearnessAllowance = employee.BasicSalary * 0.40f;
            var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
            var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);

            var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;

            // Calculate PT based on GrossSalary
            int pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;

            var totalSalary = grossSalary - pt;

            // update the employee details to the database
            _employee.Employee.Update(employee);
            await _employee.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<EmployeeDatatable>> GetEmployeeAsync()
        {
            var employees = await _employee.Employee.ToListAsync();

            if (employees.Count == 0) // If there are no employees, return an empty list
            {
                return new List<EmployeeDatatable>();
            }

            // Create a list to hold EmployeeDatatable objects
            var employeeDatatableList = new List<EmployeeDatatable>();

            foreach (var employee in employees)
            {
                // Calculate allowances and salary
                var dearnessAllowance = employee.BasicSalary * 0.40f;
                var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
                var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);
                var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;
                var pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;
                var totalSalary = grossSalary - pt;
                // Create a new EmployeeDatatable object for each employee and assign the values

                var da = new EmployeeDatatable
                {
                    Id = employee.Id,
                    EmployeeCode = employee.EmployeeCode,
                    EmployeeName = employee.EmployeeName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Department = employee.Department,
                    Designation = employee.Designation,
                    BasicSalary = employee.BasicSalary,
                    dearnessAllowance = dearnessAllowance,
                    conveyanceAllowance = conveyanceAllowance,
                    houseRentAllowance = houseRentAllowance,
                    pt = pt,
                    totalSalary = totalSalary
                };

                // Add the EmployeeDatatable object to the list
                employeeDatatableList.Add(da);
            }

            // Return the list as IEnumerable
            return employeeDatatableList;
        }



        public async Task<EmployeeDatatable> GetEmployeeByIdAsync(int Id)
        {
            var employee= await _employee.Employee.Where(ep => ep.Id == Id).SingleOrDefaultAsync();
                // Calculate allowances and salary
                var dearnessAllowance = employee.BasicSalary * 0.40f;
                var conveyanceAllowance = Math.Min(dearnessAllowance * 0.10f, 250);
                var houseRentAllowance = Math.Max(employee.BasicSalary * 0.25f, 1500);
                var grossSalary = employee.BasicSalary + dearnessAllowance + conveyanceAllowance + houseRentAllowance;
                var pt = grossSalary <= 3000 ? 100 : grossSalary <= 6000 ? 150 : 200;
                var totalSalary = grossSalary - pt;
                // Create a new EmployeeDatatable object for each employee and assign the values

                var da = new EmployeeDatatable
                {
                    Id = employee.Id,
                    EmployeeCode = employee.EmployeeCode,
                    EmployeeName = employee.EmployeeName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender,
                    Department = employee.Department,
                    Designation = employee.Designation,
                    BasicSalary = employee.BasicSalary,
                    dearnessAllowance = dearnessAllowance,
                    conveyanceAllowance = conveyanceAllowance,
                    houseRentAllowance = houseRentAllowance,
                    pt = pt,
                    totalSalary = totalSalary
                };
            return da;
        }

        public async void SaveChangesAsync()
        {
             await _employee.SaveChangesAsync();
        }
    }
}
