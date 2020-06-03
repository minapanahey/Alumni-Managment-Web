using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlumniManagment.Models;
using System.ComponentModel.DataAnnotations;

namespace AlumniManagment.Dtos
{
    public class eventRegistrationDto
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Want to regsiter For Dinner?")]
        public bool isDinner { get; set; }

        [Required]
        [Display(Name = "Want to regsiter For Shirt?")]
        public bool isShirt { get; set; }


        public Event events { get; set; }
        public Payment payment { get; set; }
        public ApplicationUser user { get; set; }
    }
}