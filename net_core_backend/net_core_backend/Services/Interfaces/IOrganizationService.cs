using net_core_backend.Models;
using System.Threading.Tasks;

namespace net_core_backend.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<Organizations> GetOrganization();
    }
}