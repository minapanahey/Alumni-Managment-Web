using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AlumniManagment.Dtos;

namespace AlumniManagment.Models.ViewModels
{
    public class SettingViewMolde
    {
        public UserDto user { get; set; }
        public AccountPrivacyDto privacy { get; set; }
    }
}