using System;
using System.Collections.Generic;

namespace net_core_backend.Models
{
    public partial class UserInvites : DefaultModel
    {
        public int UserId { get; set; }
        public string InviteToken { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Users User { get; set; }
    }
}
