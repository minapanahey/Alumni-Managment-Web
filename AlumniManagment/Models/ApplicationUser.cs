using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(21)]
        [StringLength(21)]
        [Display(Name = "Registration No")]
        public string regNo { get; set; }

        [Required(ErrorMessage = "Enter First Name:")]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name:")]
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please Select Profile Picture")]
        public string profilePicture { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Facebook Link To Your Profile")]
        [DataType(DataType.Url)]
        [Url]
        public string facebookLink { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Instagram Link To Your Profile")]
        [DataType(DataType.Url)]
        [Url]
        public string instagramLink { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Twitter Link To Your Profile")]
        [DataType(DataType.Url)]
        [Url]
        public string twitterLink { get; set; }

        [Required(ErrorMessage = "Enter Date Of Birth:")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        // Navigation
        public List<CommunityMember> communityMembers { get; set; }

        //Navigation Property
        public List<PollAnswers> PollAnswers { get; set; }
    }
}
