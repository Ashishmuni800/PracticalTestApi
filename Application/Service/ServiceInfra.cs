using Application.ServiceInterface;
using AutoMapper;
using Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ServiceInfra : IServiceInfra
    {
        private readonly IServiceInfraRepo _infra;
        private readonly IMapper _Mapp;
        public ServiceInfra(IServiceInfraRepo infra, IMapper Mapp)
        {
            _infra = infra;
            _Mapp = Mapp;
            AuthService = new AuthService(_infra, Mapp);
            EmployeeService = new EmployeeService(_infra, Mapp);
        }
        public IEmployeeService EmployeeService { get; set; }
        public IAuthService AuthService { get; set; }
    }
}
