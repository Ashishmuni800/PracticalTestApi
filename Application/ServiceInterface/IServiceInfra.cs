using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IServiceInfra
    {
        IAuthService AuthService { get; set; }
        IEmployeeService EmployeeService { get; set; }
        IPrasonalDetailsService PrasonalDetailsService { get; set; }
        ICountryService CountryService { get; set; }
        IStateService StateService { get; set; }
        ICityService CityService { get; set; }
    }
}
