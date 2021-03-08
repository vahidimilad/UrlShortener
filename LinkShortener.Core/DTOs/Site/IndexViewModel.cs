using System;
using System.Collections.Generic;
using System.Text;

namespace LinkShortener.Core.DTOs.Site
{
    public class UrlViewModel
    {
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastVisitedDate { get; set; }
    }
}
