using AlumniManagment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AccountPrivacy> accountPrivacy { get; set; }
        public DbSet<Albums> albums { get; set; }
        public DbSet<AlbumPictures> albumPictures { get; set; }
        public DbSet<Calendar> calendar { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<EventRegistration> eventRegistration { get; set; }
        public DbSet<Community> communities { get; set; }
        public DbSet<CommunityMember> communityMembers { get; set; }
        public DbSet<Polls> polls { get; set; }
        public DbSet<PollAnswers> pollAnswers { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

    }
}
