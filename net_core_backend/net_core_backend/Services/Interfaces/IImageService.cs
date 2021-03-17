using net_core_backend.Models;
using System.Threading.Tasks;

namespace net_core_backend.Services.Interfaces
{
    public interface IImageService
    {
        Task<Images[]> GetOrganizationImages();
        Task<Images[]> UploadImageInformation(UploadImageModel model);
    }
}