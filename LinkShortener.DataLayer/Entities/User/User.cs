using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LinkShortener.DataLayer.Entities.Relations;

namespace LinkShortener.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {
            
        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(200, ErrorMessage = "{0} Can not have more than {1} characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(200, ErrorMessage = "{0} Can not have more than {1} characters.")]
        public string LastName { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        public string Mobile { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(200, ErrorMessage = "{0} Can not have more than {1} characters.")]
        public string Password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required(ErrorMessage = "Please Insert {0}.")]
        [MaxLength(200, ErrorMessage = "{0} Can not have more than {1} characters.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Date of Registration")]
        public DateTime RegisterDate { get; set; }


        #region Relation with URL

        public virtual List<UserUrl> UserUrls { get; set; }
        

        #endregion
    }
}
