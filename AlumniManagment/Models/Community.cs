using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class Community
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        // Navigation
        public List<CommunityMember> communityMembers { get; set; }
    }
}
