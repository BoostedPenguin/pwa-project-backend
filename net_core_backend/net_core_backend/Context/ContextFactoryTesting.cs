using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using net_core_backend.Models;


namespace net_core_backend.Context
{
    public class ContextFactoryTesting : IDesignTimeDbContextFactory<pwaDBContext>, IContextFactory
    {
        private readonly string connectionString;

        public ContextFactoryTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public pwaDBContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<pwaDBContext>();
            options.UseInMemoryDatabase("TestingDatabase");

            return new pwaDBContext(options.Options);
        }
    }
}
