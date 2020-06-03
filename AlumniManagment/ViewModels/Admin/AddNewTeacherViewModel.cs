using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.ViewModels.Admin
{
    public class AddNewTeacherViewModel
    {
        [Required]
        public string Name { get; set; }
        public IFormFile Picture { get; set; }
        [Required]
        public string Specialization { get; set; }
        public List<SelectListItem> departments { get; set; }
        public int dept { get;set; }
    }
}
