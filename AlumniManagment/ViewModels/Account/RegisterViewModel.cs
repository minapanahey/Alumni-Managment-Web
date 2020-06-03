using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

        //[Required(ErrorMessage = "Please Select Profile Picture")]
        public IFormFile profilePicture { get; set; }
        public string profilePictureName { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Facebook Link To Your Profile")]
        [DataType(DataType.Url)]
        public string facebookLink { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Instagram Link To Your Profile")]
        [DataType(DataType.Url)]
        public string instagramLink { get; set; }

        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Add Twitter Link To Your Profile")]
        [DataType(DataType.Url)]
        public string twitterLink { get; set; }

        [Required(ErrorMessage = "Enter Date Of Birth:")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Registration No")]
        public string season { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string roll { get; set; }

        public IEnumerable<SelectListItem> seasons { get; set; }
        public IEnumerable<SelectListItem> departments { get; set; }
    }
}
