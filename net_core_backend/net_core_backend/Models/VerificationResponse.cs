using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    /// <summary>
    /// Content of JWT Token
    /// </summary>
    public class VerificationResponse
    {
        public int Id { get; set; }
        public bool Admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Organizations Organization { get; set; }

        public VerificationResponse(Users user, string token, Organizations organizations)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
            Organization = organizations;
            Admin = user.Admin;
        }
    }
}
