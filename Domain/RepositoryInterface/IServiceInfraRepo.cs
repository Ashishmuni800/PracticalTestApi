using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IServiceInfraRepo
    {
        IAuthRepo AuthRepo { get; set; }
        IEmployeeRepo EmployeeRepo { get; set; }
    }
}
