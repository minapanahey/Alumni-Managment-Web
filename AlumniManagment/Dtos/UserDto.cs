﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AlumniManagment.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Enter Email:")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserName { get; set; }

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
    }
}