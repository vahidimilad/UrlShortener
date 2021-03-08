using System;
using System.Collections.Generic;
using System.Text;
using LinkShortener.Core.DTOs.Site;
using LinkShortener.DataLayer.Entities.Url;

namespace LinkShortener.Core.Services.Interfaces
{
    public interface IUserService
    {
        List<UrlViewModel> GetUserUrlList(int userId);
    }
}
