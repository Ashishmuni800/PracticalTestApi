using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AspNetUsersDTO
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Roles { get; set; }
        public string? Images { get; set; }
        public DateTime? ExpiredateTime { get; set; }
    }

}
