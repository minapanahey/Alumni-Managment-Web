using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AlumniManagment.Models;
using AlumniManagment.Dtos;
using AlumniManagment.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AlumniManagment.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AlumniManagment.Controllers.api
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public ProfileController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/profile/{id}")]
        public IActionResult GetProfile(string id)
        {
            ApplicationUser user = dbContext.Users.SingleOrDefault(u => u.Id == id);
            ////
            return Ok(mapper.Map<ApplicationUser,UserDto>(user));
        }

        [HttpPut]
        [Route("api/profile/{id}")]
        public IActionResult Update(string id, [FromBody]SettingViewMolde model)
        {
            model.user.UserName = model.user.Email;
            ApplicationUser user = dbContext.Users.SingleOrDefault(m => m.Id == id);
            AccountPrivacy privacy = dbContext.accountPrivacy.SingleOrDefault(m => m.userId == id);

            mapper.Map<UserDto, ApplicationUser>(model.user,user);

            mapper.Map<AccountPrivacyDto, AccountPrivacy>(model.privacy,privacy);

            dbContext.SaveChanges();
            return Ok(model);
        }

        [HttpGet]
        [Route("api/profile/privacy/{id}")]
        public IActionResult Privacy(string id)
        {
             AccountPrivacy privacy = dbContext.accountPrivacy.SingleOrDefault(ap => ap.userId == id);
            string x = HttpContext.Session.GetString("userId");
            return Ok(mapper.Map<AccountPrivacy,AccountPrivacyDto>(privacy));
        }

        [HttpGet]
        [Route("api/profile/registeredEvents/{userId}")]
        public IActionResult getRegisteredEvents(string userId)
        {
            IEnumerable<EventRegistration> eventRegistration = dbContext.eventRegistration.Where(er => er.userId.Equals(userId)).Include(er => er.events).Include(e => e.events.calendar).ToList();
            IEnumerable<eventRegistrationDto> eventRegistrationDto = mapper.Map<IEnumerable<EventRegistration>, IEnumerable<eventRegistrationDto>>(eventRegistration);

            return Ok(eventRegistrationDto);
        }

        [HttpGet]
        [Route("api/profile/getEmailFromRegistrationNo/{regNo}")]
        [AllowAnonymous]
        public IActionResult getEmailFromRegistrationNo(string regNo)
        {
            string email = dbContext.Users.Where(u => u.regNo == regNo).Select(u => u.Email).SingleOrDefault();
            if(email == null)
            {
                return NotFound();
            }
            return Ok(email);
        }
    }
}
