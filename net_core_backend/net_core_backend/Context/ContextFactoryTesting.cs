using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using net_core_backend.Models;


namespace net_core_backend.Context
{
    public class ContextFactoryTesting : IDesignTimeDbContextFactory<ProjectContext>, IContextFactory
    {
        private readonly string connectionString;

        public ContextFactoryTesting(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ProjectContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ProjectContext>();
            options.UseInMemoryDatabase("TestingDatabase");

            return new ProjectContext(options.Options);
        }
    }
}
