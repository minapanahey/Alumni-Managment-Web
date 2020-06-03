using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AlumniManagment.Models;
using AlumniManagment.Models.ViewModels;
using AlumniManagment.Dtos;
using AutoMapper;
using AlumniManagment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AlumniManagment.Controllers.api
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EventController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/event/{id}")]
        public IActionResult GetEvent(int id)
        {
            Event events = dbContext.events.SingleOrDefault(e => e.id == id);
            if(events != null)
            {
                return Ok(mapper.Map<Event, EventDto>(events));
            }
            //ApplicationUser user = dbContext.Users.SingleOrDefault(u => u.Id == id);

            //return Ok(Mapper.Map<ApplicationUser, UserDto>(user));
            return NotFound("Event Not Found");
            ////return  Content(HttpStatusCode.NotFound,"Event Not Found");
        }

        [HttpGet]
        [Route("api/allEvents/{userId}")]
        public IActionResult GetAllEvent(string userId)
        {
            IEnumerable<int> alreadyRegisteredEvents = dbContext.eventRegistration.Where(e => e.userId == userId).Select(e => e.eventId).ToList();
            IEnumerable<Event> events = dbContext.events.Include("calendar").Where(e=> !alreadyRegisteredEvents.Contains(e.id)).ToList();

            IEnumerable<EventDto> eventsDto = 
                mapper.Map<IEnumerable<Event>, IEnumerable<EventDto>>(events);

            return Ok(eventsDto);
        }

        [HttpPost]
        [Route("api/event")]
        [Authorize(Roles ="admin")]
        public IActionResult CreateEvent([FromBody]EventViewModel model)
        {
            if(ModelState.IsValid)
            {
                Calendar calendar = mapper.Map<CalendarDto, Calendar>(model.calendarDto);
                Event eventToCreate = mapper.Map<EventDto, Event>(model.eventDto);
                eventToCreate.calendar = calendar;

                dbContext.events.Add(eventToCreate);

                dbContext.SaveChanges();

                return Ok("Event Added Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("api/event/register/{eventId}/{userId}")]
        public IActionResult registerUserToEvent(int eventId, string userId, [FromBody]eventRegistrationDto model)
        {
            EventRegistration registration = mapper.Map<eventRegistrationDto, EventRegistration>(model);
            registration.userId = userId;
            registration.eventId = eventId;
            registration.payment = new Payment() {
                amount = 1000,
                dateTime = DateTime.Now,
                descripton = "event"
            };

            dbContext.eventRegistration.Add(registration);
            dbContext.SaveChanges();
            return Ok("Registerd Successfully");
        }

        
    }
}
