using System;
using System.Collections.Generic;
using System.Text;
using LinkShortener.DataLayer.Entities.Relations;
using LinkShortener.DataLayer.Entities.Url;
using LinkShortener.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.DataLayer.Context
{
    public class LinkShortenerContext:DbContext
    {
        public LinkShortenerContext(DbContextOptions<LinkShortenerContext> options):base(options)
        {
            
        }
        #region User

        public DbSet<User> Users { get; set; }

        #endregion

        #region Url

        public DbSet<Url> Urls { get; set; }

        #endregion

        #region Relations

        public DbSet<UserUrl> UserUrls { get; set; }

        #endregion
    }
}
