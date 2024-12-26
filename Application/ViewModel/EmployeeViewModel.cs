using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; } // true for Male, false for Female
        public string? Department { get; set; }
        public string? Designation { get; set; }
        public float BasicSalary { get; set; }
    }
}
