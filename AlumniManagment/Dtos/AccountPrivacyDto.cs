using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AlumniManagment.Dtos
{
    public class AccountPrivacyDto
    {
        public AccountPrivacyDto()
        {
            facebookIsPublic = false;
            instagramIsPublic = false;
            emailIsPublic = false;
            twitterIsPublic = false;
        }

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
        [Display(Name = "Do you want to show your email to others?")]
        public bool emailIsPublic { get; set; }
    }
}