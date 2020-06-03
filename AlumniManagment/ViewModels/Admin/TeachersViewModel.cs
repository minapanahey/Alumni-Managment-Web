using AlumniManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.ViewModels.Admin
{
    public class TeachersViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public AddNewTeacherViewModel AddNewTeacherViewModel { get; set; }
    }
}
