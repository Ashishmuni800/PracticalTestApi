using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PrasonalDetails : CommanField
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public int StateId { get; set; }
        public State? State { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
    }
}
