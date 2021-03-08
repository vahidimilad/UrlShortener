using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkShortener.Core.DTOs.Site;
using LinkShortener.Core.Services.Interfaces;
using LinkShortener.DataLayer.Context;
using LinkShortener.DataLayer.Entities.Relations;
using LinkShortener.DataLayer.Entities.Url;

namespace LinkShortener.Core.Services
{
    public class UserService:IUserService
    {
        private LinkShortenerContext _context;

        public UserService(LinkShortenerContext context)
        {
            _context = context;
        }


        public List<UrlViewModel> GetUserUrlList(int userId)
        {
            return _context.UserUrls.Where(u => u.UserId == userId).Select(u=> new UrlViewModel()
            {
                OriginalUrl = u.Url.OriginalUrl,
                ShortUrl = "https://localhost:44398/" + u.Url.ShortKey,
                Clicks = u.Url.Clicks,
                CreatedDate = u.Url.CreatedDate,
                LastVisitedDate = u.Url.CreatedDate,
            }).ToList();
        }
    }
}
