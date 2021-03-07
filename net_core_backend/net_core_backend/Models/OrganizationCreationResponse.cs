using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class OrganizationCreationResponse
    {
        public Organizations Organizations { get; set; }
        public int Id { get; set; }
        public bool Admin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public OrganizationCreationResponse(Users user, string token, Organizations organizations)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
            Admin = user.Admin;
            Organizations = organizations;
        }
    }
}
