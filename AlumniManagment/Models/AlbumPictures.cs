using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlumniManagment.Models
{
    [Table("AlbumPictures")]
    public class AlbumPictures
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Select A Picture")]
        [Display(Name = "Picture")]
        public string picture { get; set; }

        [ForeignKey("album")]
        public int albumId { get; set; }
        public Albums album { get; set; }
    }
}