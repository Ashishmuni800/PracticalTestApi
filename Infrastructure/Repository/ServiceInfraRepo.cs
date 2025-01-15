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
        }
        public IAuthRepo AuthRepo { get; set; }
        public IEmployeeRepo EmployeeRepo { get; set; }
    }
}
