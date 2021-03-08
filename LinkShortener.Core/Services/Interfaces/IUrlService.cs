using System;
using System.Collections.Generic;
using System.Text;
using LinkShortener.Core.DTOs.Site;
using LinkShortener.DataLayer.Entities.Url;

namespace LinkShortener.Core.Services.Interfaces
{
    public interface IUrlService
    {
        string GetShortKeyForOriginalUrl(string url);
        Url AddUrl(string originalUrl, string shortUrl);
        void AddUserUrl(int userId, int urlId);
        string FindOriginalUrlByShortKey(string shortKey);
        int CountUserLinks(int userId);
        int CountUserLinksTotalClicks(int userId);
        void IncrementUrlClicks(string shortKey);
        List<Url> GetUrlListStatus(int userId);
    }
}
