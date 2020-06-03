using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    [Table("Payments")]
    public class Payment
    {
        public Payment()
        {
            descripton = "Event";
        }

        public int id { get; set; }

        [Required]
        public int amount { get; set; }

        [Display(Name = "Payment Time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dateTime { get; set; }

        [Required]
        public string descripton { get; set; }
    }
}