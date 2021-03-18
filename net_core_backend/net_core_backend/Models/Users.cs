using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace net_core_backend.Models
{
    public partial class Users : DefaultModel
    {
        public Users()
        {
            Images = new HashSet<Images>();
        }


        public Users(int orgId, string email, string fName, string lName)
        {
            this.OrganizationId = orgId;
            this.Email = email;
            this.FirstName = fName;
            this.LastName = lName;
            Images = new HashSet<Images>();
        }

        public int OrganizationId { get; set; }
        public bool Admin { get; set; }
        public bool Activated { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }
        public string Avatar { get; set; }

        public virtual Organizations Organization { get; set; }
        public virtual UserInvites UserInvites { get; set; }
        public virtual ICollection<Images> Images { get; set; }
    }
}
