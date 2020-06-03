using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AlumniManagment.Models;

namespace AlumniManagment.Dtos
{
    public class EventDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Title Can't Be Null")]
        [StringLength(maximumLength: 100, MinimumLength = 15, ErrorMessage = "Minimum Length {1} and Maximum Length{0}")]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Discription Can't Be Null")]
        [StringLength(maximumLength: 300, MinimumLength = 35, ErrorMessage = "Minimum Length {1} and Maximum Length{0}")]
        [MaxLength(300)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Please Enter Registration Fee")]
        [Display(Name = "Registration Fee")]
        public int registrationFee { get; set; }

        [Required(ErrorMessage = "Please Enter Shirt Charge")]
        [Display(Name = "Shirt Fee")]
        public int shirtFee { get; set; }

        [Required(ErrorMessage = "Please Enter Dinner Charge")]
        [Display(Name = "Dinner Charge")]
        public int dinnerFee { get; set; }

        [Required(ErrorMessage = "Enter Google Map Link Of The Event Location")]
        [Url]
        [Display(Name = "Event Locaiton")]
        public string locationLink { get; set; }

        public Calendar calendar { get; set; }
    }
}