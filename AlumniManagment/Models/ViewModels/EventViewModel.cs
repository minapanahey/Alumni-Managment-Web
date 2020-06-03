using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlumniManagment.Dtos;

namespace AlumniManagment.Models.ViewModels
{
    public class EventViewModel
    {
        public EventDto eventDto { get;set; }
        public CalendarDto calendarDto{ get;set; }
    }
}