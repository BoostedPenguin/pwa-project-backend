﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class OrganizationCreationResponse
    {
        public bool Admin { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public Organizations Organization { get; set; }

        public OrganizationCreationResponse(Users user, string token, Organizations organization)
        {
            Admin = user.Admin;
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
            Organization = organization;
        }
    }
}
