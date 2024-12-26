using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeCode { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; } // true for Male, false for Female
        [Required]
        public string? Department { get; set; }
        [Required]
        public string? Designation { get; set; }
        [Required]
        public float BasicSalary { get; set; }
    }
    
}
