using InfrastructDomain.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DbConnectionAdo
    {
        public SqlConnection cnn;
        public DbConnectionAdo()
        {
            cnn = new SqlConnection(DbConfigAdo.connectionStr);
        }
    }
}
