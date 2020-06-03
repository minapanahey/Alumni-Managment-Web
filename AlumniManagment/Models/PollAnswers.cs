using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class PollAnswers
    {
        public int Id { get; set; }
        [Required]
        public string Answer { get; set; }
        public Polls Polls { get; set; }
        public ApplicationUser User {get;set;}

        [ForeignKey("User")]
        [Required]
        public string UserId {get;set;}
        
        [ForeignKey("Polls")]
        [Required]
        public int PollId { get; set; }
    }
}
