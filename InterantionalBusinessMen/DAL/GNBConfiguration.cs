using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace InterantionalBusinessMen.DAL
{
    public class GNBConfiguration : DbConfiguration
    {
        public GNBConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}