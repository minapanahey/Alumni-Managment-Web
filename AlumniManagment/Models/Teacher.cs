using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Specialization { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }
    }
}
