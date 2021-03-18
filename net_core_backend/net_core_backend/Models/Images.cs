using System;
using System.Collections.Generic;

namespace net_core_backend.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StoreId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string DeleteUrl { get; set; }
        public DateTime UploadedAt { get; set; }

        public virtual Users User { get; set; }
    }
}
