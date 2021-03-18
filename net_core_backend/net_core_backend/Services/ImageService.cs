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
    public class ImageService : DataService<DefaultModel>, IImageService
    {
        private readonly IContextFactory contextFactory;
        private readonly IHttpContextAccessor httpContext;

        public ImageService(IContextFactory _contextFactory, IHttpContextAccessor httpContext) : base(_contextFactory)
        {
            contextFactory = _contextFactory;
            this.httpContext = httpContext;
        }


        public async Task<Images[]> UploadImageInformation(UploadImageModel model)
        {
            using (var a = contextFactory.CreateDbContext())
            {
                var user = await a.Users.Where(x => x.Id == httpContext.GetCurrentUserId()).FirstOrDefaultAsync();

                if (user == null) throw new ArgumentException("No person with that id");

                user.Images.Add(new Images()
                {
                    Url = model.Url,
                    DeleteUrl = model.DeleteURL,
                    StoreId = model.Id,
                    UserId = user.Id,
                    UploadedAt = model.UploadedAt,
                    Title = model.Title,
                    Description = model.Description
                });

                await a.SaveChangesAsync();

                return await GetOrganizationImages();
            }
        }

        public async Task<Images[]> GetOrganizationImages()
        {
            using (var a = contextFactory.CreateDbContext())
            {
                var user = await a.Users.Where(x => x.Id == httpContext.GetCurrentUserId()).FirstOrDefaultAsync();

                if (user == null) throw new ArgumentException("No person with that id");

                var images = await a.Images.Include(x => x.User).Where(x => x.User.OrganizationId == user.OrganizationId).OrderBy(x => x.UploadedAt).ToListAsync();

                return images.ToArray();
            }
        }
    }
}
