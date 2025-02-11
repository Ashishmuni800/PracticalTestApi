using Domain.RepositoryInterface;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ServiceInfraRepo : IServiceInfraRepo
    {
        private readonly ApplicationDbContext _DbContext;
        public ServiceInfraRepo(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
            AuthRepo = new AuthRepo(_DbContext);
            EmployeeRepo = new EmployeeRepo(_DbContext);
            PrasonalDetailsRepo = new PrasonalDetailsRepo(_DbContext);
            CountryRepo = new CountryRepo(_DbContext);
            StateRepo = new StateRepo(_DbContext);
            CityRepo = new CityRepo(_DbContext);
        }
        public IAuthRepo AuthRepo { get; set; }
        public IEmployeeRepo EmployeeRepo { get; set; }
        public IPrasonalDetailsRepo PrasonalDetailsRepo { get; set; }
        public ICountryRepo CountryRepo { get; set; }
        public IStateRepo StateRepo { get; set; }
        public ICityRepo CityRepo { get; set; }
    }
}
