using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace net_core_backend.Models
{
    public partial class Users : DefaultModel
    {
        public Users()
        {
        }

        public Users(int orgId, string email, string fName, string lName)
        {
            this.OrganizationId = orgId;
            this.Email = email;
            this.FirstName = fName;
            this.LastName = lName;
        }

        public int OrganizationId { get; set; }
        public bool Admin { get; set; }
        public bool Activated { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public string Avatar { get; set; }

        public virtual Organizations Organization { get; set; }
        public virtual UserInvites UserInvites { get; set; }
    }
}
