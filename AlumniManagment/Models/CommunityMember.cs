using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class CommunityMember
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Community Community { get; set; }
        [ForeignKey("Community")]
        public int CommunityId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
