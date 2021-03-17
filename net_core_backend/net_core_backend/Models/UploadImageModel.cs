using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Models
{
    public class UploadImageModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string DeleteURL { get; set; }
        public DateTime UploadTime { get; set; }
    }
}
