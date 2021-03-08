using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LinkShortener.DataLayer.Entities.Relations;

namespace LinkShortener.DataLayer.Entities.Url
{
    public class Url
    {
        public Url()
        {
            
        }

        [Key]
        public int UrlId { get; set; }

        [Display(Name = "Original URL")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        public string OriginalUrl { get; set; }



        [Display(Name = "Short key")]
        public string ShortKey { get; set; }


        [Display(Name = "Number of Clicks")]
        public int Clicks { get; set; }


        [Display(Name = "Last Visit")]
        public DateTime? LastVisitDate { get; set; }


        [Display(Name = "Link Created Date")]
        public DateTime CreatedDate { get; set; }


        #region Relation With UserRole

        public virtual List<UserUrl> UserUrls { get; set; }

        

        #endregion
    }
}
