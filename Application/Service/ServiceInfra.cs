using Application.ServiceInterface;
using AutoMapper;
using Domain.RepositoryInterface;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ServiceInfra : IServiceInfra
    {
        private readonly ServiceInfraRepo _infra;
        private readonly IMapper _Mapp;
        public ServiceInfra(IServiceInfraRepo infra, IMapper Mapp)
        {
            _infra = (ServiceInfraRepo?)infra;
            _Mapp = Mapp;
            AuthService = new AuthService(_infra, Mapp);
            EmployeeService = new EmployeeService(_infra, Mapp);
            PrasonalDetailsService = new PrasonalDetailsService(_infra, Mapp);
            CountryService = new CountryService(_infra, Mapp);
            StateService = new StateService(_infra, Mapp);
            CityService = new CityService(_infra, Mapp);
        }
        public IEmployeeService EmployeeService { get; set; }
        public IAuthService AuthService { get; set; }
        public IPrasonalDetailsService PrasonalDetailsService { get; set; }
        public ICountryService CountryService { get; set; }
        public IStateService StateService { get; set; }
        public ICityService CityService { get; set; }
    }
}
