using net_core_backend.Models;
using System.Threading.Tasks;

namespace net_core_backend.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> AddUser(AddUserRequest requestInfo);
        Task<OrganizationCreationResponse> CreateOrganization(CreateOrganizationRequest request);
        Task<Users> GetUserDetailsJWT(int id);
        Task<VerificationResponse> UserVerification(VerificationRequest model);
    }
}