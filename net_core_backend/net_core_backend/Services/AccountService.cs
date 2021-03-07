using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using net_core_backend.Context;
using net_core_backend.Helpers;
using net_core_backend.Models;
using net_core_backend.Services.Interfaces;
using net_core_backend.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace net_core_backend.Services
{
    public class AccountService : DataService<DefaultModel>, IAccountService
    {
        private readonly IContextFactory contextFactory;
        private readonly IHttpContextAccessor httpContext;
        private readonly AppSettings appSettings;
        public AccountService(IContextFactory _contextFactory, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContext) : base(_contextFactory)
        {
            contextFactory = _contextFactory;
            this.httpContext = httpContext;
            this.appSettings = appSettings.Value;
        }


        public async Task<Users> GetUserDetailsJWT(int id)
        {
            if (id == 0) throw new ArgumentException("There is no ID in the JWT Token");

            using (var a = contextFactory.CreateDbContext())
            {
                return await a.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }


        public async Task<string> AddUser(AddUserRequest requestInfo)
        {
            using (var a = contextFactory.CreateDbContext())
            {
                // Checks for existing
                if (await a.Users.FirstOrDefaultAsync(x => x.Email == requestInfo.Email && x.OrganizationId == requestInfo.OrganizationId) != null)
                {
                    throw new ArgumentException("There is already a user with this email in this organization");
                }

                // Creates and adds a user
                int parentOrgId = await a.Users.Where(x => x.Id == httpContext.GetCurrentUserId()).Select(x => x.OrganizationId).FirstOrDefaultAsync();
                
                var user = new Users(parentOrgId, 
                    requestInfo.Email, 
                    requestInfo.FirstName, 
                    requestInfo.LastName);

                await a.Users.AddAsync(user);

                // Creates a unique token
                string token = Guid.NewGuid().ToString();

                var userInvite = new UserInvites()
                {
                    UserId = user.Id,
                    InviteToken = token,
                };

                await a.UserInvites.AddAsync(userInvite);
                await a.SaveChangesAsync();

                return token;
            }
        }


        /// <summary>
        /// On user token activation
        /// </summary>
        /// <param name="model"></param>
        public async Task<VerificationResponse> UserVerification(VerificationRequest model)
        {
            Users user = null;

            using (var a = contextFactory.CreateDbContext())
            {
                // Get user by invite token and check if he's already activated
                user = await a.Users.Include(x => x.UserInvites).Where(x => x.UserInvites.InviteToken == model.InviteToken && x.Activated == false).FirstOrDefaultAsync();

                if (user == null) throw new ArgumentException("There is no invite pending for this token");

                user.Activated = true;

                user.HashedPassword = BC.HashPassword(model.Password);

                await a.SaveChangesAsync();
            }

            var token = generateJwtToken(user);

            return new VerificationResponse(user, token);
        }


        public async Task<OrganizationCreationResponse> CreateOrganization(CreateOrganizationRequest request)
        {
            using(var a = contextFactory.CreateDbContext())
            {
                var existingUser = await a.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
                if(existingUser != null)
                {
                    throw new ArgumentException("Each email can only participate in 1 organization");
                }

                if(await a.Organizations.FirstOrDefaultAsync(x => x.Name.ToLower() == request.OrganizationName.ToLower()) != null)
                {
                    throw new ArgumentException("There is already an organization with that name!");
                }

                var org = new Organizations() { Name = request.OrganizationName };

                var password = BC.HashPassword(request.Password);

                var user = new Users() 
                { 
                    Admin = true, 
                    Activated = true, 
                    Email = request.Email, 
                    FirstName = request.FirstName, 
                    LastName = request.LastName, 
                    OrganizationId = org.Id,
                    HashedPassword = password,
                };

                org.Users.Add(user);

                await a.AddAsync(org);

                await a.SaveChangesAsync();

                var token = generateJwtToken(user);

                return new OrganizationCreationResponse(user, token, org);
            }
        }

        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
