using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinkShortener.Core.DTOs.Site;
using LinkShortener.Core.Generators;
using LinkShortener.Core.Services.Interfaces;
using LinkShortener.DataLayer.Context;
using LinkShortener.DataLayer.Entities.Relations;
using LinkShortener.DataLayer.Entities.Url;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Core.Services
{
    public class UrlService:IUrlService
    {
        private LinkShortenerContext _context;

        public UrlService(LinkShortenerContext context)
        {
            _context = context;
        }

        public string GetShortKeyForOriginalUrl(string url)
        {
            var shortKey = CodeGenerator.GenerateUniqueCode();
            while (_context.Urls.Any(s => s.ShortKey == shortKey))
            {
                shortKey = CodeGenerator.GenerateUniqueCode();
            }
            return shortKey;
        }

        public Url AddUrl(string originalUrl, string shortKey)
        {
            Url newUrl=new Url();
            newUrl.OriginalUrl = originalUrl;
            newUrl.ShortKey = shortKey;
            newUrl.Clicks = 0;
            newUrl.CreatedDate=DateTime.Now;
            newUrl.LastVisitDate = null;
            _context.Urls.Add(newUrl);
            _context.SaveChanges();
            AddUserUrl(1, newUrl.UrlId);
            return newUrl;
        }

        public void AddUserUrl(int userId, int urlId)
        {
            _context.Add(new UserUrl()
            {
                UserId = userId,
                UrlId = urlId
            });
            _context.SaveChanges();
        }

        public string FindOriginalUrlByShortKey(string shortKey)
        {

            return _context.Urls.SingleOrDefault(u => u.ShortKey == shortKey).OriginalUrl;

        }

        public int CountUserLinks(int userId)
        {
            return _context.UserUrls.Count(u => u.UserId == userId);
        }

        public int CountUserLinksTotalClicks(int userId)
        {
            return _context.UserUrls.Include(u => u.Url).Include(u => u.User).Where(u => u.UserId == userId)
                .Where(u => u.Url.UrlId == u.UrlId).Sum(u => u.Url.Clicks);
        }

        public void IncrementUrlClicks(string shortKey)
        {
            Url url=_context.Urls.SingleOrDefault(u => u.ShortKey == shortKey);
            url.Clicks += 1;
            _context.Urls.Update(url);
            _context.SaveChanges();
        }

        public List<Url> GetUrlListStatus(int userId)
        {
            return _context.Urls.ToList();
        }
    }
}
