using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class State : CommanField
    {
        public string? StateName { get; set; }
        public string? CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
