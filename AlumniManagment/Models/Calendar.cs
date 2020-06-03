using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    [Table("Calandar")]
    public class Calendar
    {
        public int id { get; set; }

        [Display(Name = "Event Start")]
        [Required(ErrorMessage = "Enter Start Date/Time of Event:")]
        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }

        [Display(Name = "Event End")]
        [Required(ErrorMessage = "Enter End Date/Time of Event:")]
        [DataType(DataType.DateTime)]
        public DateTime end { get; set; }

    }
}