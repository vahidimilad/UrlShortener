using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinkShortener.DataLayer.Entities.Relations
{
    public class UserUrl
    {
        public UserUrl()
        {
            
        }

        [Key]
        public int UU_Id { get; set; }
        public int UserId { get; set; }
        public int UrlId { get; set; }


        #region Relations
        public virtual User.User User { get; set; }
        public virtual Url.Url Url { get; set; }

        #endregion
    }
}
