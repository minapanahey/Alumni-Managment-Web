using AlumniManagment.Dtos;
using AlumniManagment.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<AccountPrivacy, AccountPrivacyDto>();
            CreateMap<AccountPrivacyDto, AccountPrivacy>();

            CreateMap<Calendar, CalendarDto>();
            CreateMap<CalendarDto, Calendar>();

            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();

            CreateMap<EventRegistration, eventRegistrationDto>();
            CreateMap<eventRegistrationDto, EventRegistration>();
        }
    }
}
