using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CityDTO : CommanFieldDTO
    {
        public string? CityName { get; set; }
        public string? StateId { get; set; }
        public State? State { get; set; }
    }
}
