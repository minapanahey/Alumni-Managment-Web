using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.ViewModels.Account
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string userName { get; set; }

        [Display(Name = "Registration No")]
        [Required]
        public string season { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string roll { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        public bool rememberMe { get; set; }

        public IEnumerable<SelectListItem> seasons { get; set; }
        public IEnumerable<SelectListItem> departments { get; set; }
    }
}
