using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    [Table("Albums")]
    public class Albums
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter A Name For New Album")]
        [StringLength(200)]
        [MaxLength(200)]
        [Display(Name = "Album Name")]
        public string albumName { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }
        public ApplicationUser user { get; set; }
    }
}