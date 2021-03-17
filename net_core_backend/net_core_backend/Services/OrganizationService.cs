using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using net_core_backend.Context;
using net_core_backend.Models;
using net_core_backend.Services.Extensions;
using net_core_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Services
{
    public class OrganizationService : DataService<DefaultModel>, IOrganizationService
    {
        private readonly IContextFactory contextFactory;
        private readonly IHttpContextAccessor httpContext;

        public OrganizationService(IContextFactory _contextFactory, IHttpContextAccessor httpContextAccessor) : base(_contextFactory)
        {
            contextFactory = _contextFactory;
            httpContext = httpContextAccessor;
        }

        public async Task<Organizations> GetOrganization()
        {
            using (var a = contextFactory.CreateDbContext())
            {
                var userOrganizationId = await a.Users.Where(x => x.Id == httpContext.GetCurrentUserId()).Select(x => x.OrganizationId).FirstOrDefaultAsync();

                var org = await a.Organizations.Include(x => x.Users).Where(x => x.Id == userOrganizationId).FirstOrDefaultAsync();

                return org;
            }
        }
    }
}
