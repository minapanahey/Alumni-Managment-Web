using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    public class EventRegistration
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Want to regsiter For Dinner?")]
        public bool isDinner { get; set; }

        [Required]
        [Display(Name = "Want to regsiter For Shirt?")]
        public bool isShirt { get; set; }


        [ForeignKey("events")]
        public int eventId { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }

        [ForeignKey("payment")]
        public int paymentId { get; set; }

        public Event events { get; set; }
        public Payment payment { get; set; }
        public ApplicationUser user { get; set; }

    }
}