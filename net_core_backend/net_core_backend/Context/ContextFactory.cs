using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using net_core_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ProjectContext>, IContextFactory
    {
        private readonly string connectionString;
        public ContextFactory(string connectionString)
        {
            this.connectionString = connectionString;


            var options = new DbContextOptionsBuilder<ProjectContext>();
            options.UseInMemoryDatabase("someDb");

            var context = new ProjectContext(options.Options);
            
            context.Database.EnsureCreated();
        }

        public ProjectContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ProjectContext>();
            options.UseInMemoryDatabase("someDb");

            return new ProjectContext(options.Options);
        }
    }
}
