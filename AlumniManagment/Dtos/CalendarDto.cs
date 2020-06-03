using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AlumniManagment.Dtos
{
    public class CalendarDto
    {
        public int id { get; set; }

        [Display(Name = "Event Start")]
        [Required(ErrorMessage = "Enter Start Date/Time of Event:")]
        [DataType(DataType.Date)]
        public DateTime start { get; set; }

        [Display(Name = "Event End")]
        [Required(ErrorMessage = "Enter End Date/Time of Event:")]
        [DataType(DataType.Date)]
        public DateTime end { get; set; }
    }
}