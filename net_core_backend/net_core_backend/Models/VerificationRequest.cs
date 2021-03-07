using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class VerificationRequest
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string InviteToken { get; set; }
    }
}
