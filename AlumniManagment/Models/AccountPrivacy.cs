using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    [Table("AccountPrivacy")]
    public class AccountPrivacy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select One Option")]
        [Display(Name = "Do you want to show your facebook profile link to others?")]
        public bool facebookIsPublic { get; set; }

        [Required(ErrorMessage = "Please Select One Option")]
        [Display(Name = "Do you want to show your instagram profile link to others?")]
        public bool instagramIsPublic { get; set; }

        [Required(ErrorMessage = "Please Select One Option")]
        [Display(Name = "Do you want to show your twitter profile link to others?")]
        public bool twitterIsPublic { get; set; }

        [Required(ErrorMessage = "Please Select One Option")]
        [Display(Name = "Do you want to show your phone number to others?")]
        public bool phoneIsPublic { get; set; }

        [Required(ErrorMessage = "Please Select One Option")]
        [Display(Name = "Do you want to show your email to others?")]
        public bool emailIsPublic { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }
        
        public ApplicationUser user { get; set; }
    }
}