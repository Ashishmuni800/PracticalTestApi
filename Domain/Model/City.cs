using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class City : CommanField
    {
        public string? CityName { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
    }
}
