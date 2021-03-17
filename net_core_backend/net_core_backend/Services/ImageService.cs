using Microsoft.AspNetCore.Http;
using net_core_backend.Context;
using net_core_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Services
{
    public class ImageService : DataService<DefaultModel>
    {
        private readonly IContextFactory contextFactory;
        private readonly IHttpContextAccessor httpContext;

        public ImageService(IContextFactory _contextFactory, IHttpContextAccessor httpContext) : base(_contextFactory)
        {
            contextFactory = _contextFactory;
            this.httpContext = httpContext;
        }


        public async Task UploadImageInformation(UploadImageModel model)
        {

        } 
    }
}
