using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class Polls
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title Of The Poll")]
        public string Question { get; set; }
        //Created or done (reviewed by admin)
        public string status { get; set; } = "created";

        //Navigation Property
        public List<PollAnswers> PollAnswers { get; set; }

        [ForeignKey("calendar")]
        [Required]
        public int calendarId { get; set; }

        public Calendar calendar { get; set; }
    }
}
