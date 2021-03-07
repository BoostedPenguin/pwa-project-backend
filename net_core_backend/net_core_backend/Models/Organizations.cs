using System;
using System.Collections.Generic;

namespace net_core_backend.Models
{
    public partial class Organizations : DefaultModel
    {
        public Organizations()
        {
            Users = new HashSet<Users>();
        }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
