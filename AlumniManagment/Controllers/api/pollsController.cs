using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlumniManagment.Data;
using AlumniManagment.Models;
using AlumniManagment.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlumniManagment.Controllers.api
{
    [ApiController]
    [Authorize]
    public class pollsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserServices userServices;

        public pollsController(
            ApplicationDbContext dbContext,
            IMapper mapper,
            UserServices userServices)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userServices = userServices;
        }

        [HttpPost]
        [Route("api/polls/CreatePollAPi")]
        public IActionResult CreatePollApi([FromBody]Polls model)
        {
            if (ModelState.IsValid)
            {
                dbContext.calendar.Add(model.calendar);
                dbContext.polls.Add(model);
                dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/polls/getAllPolls/{userId}")]
        public IActionResult getAllPolls(string userId)
        {
            List<Polls> polls = dbContext.polls.Include(p => p.calendar)
                .Where(p => p.calendar.start <= DateTime.Now && p.calendar.end >= DateTime.Now && !p.PollAnswers.Select(a => a.UserId).Contains(userId))
                .ToList();
            return Ok(polls);
        }

        [HttpGet]
        [Route("api/polls/answerPollApi/{pId}/{answer}/{userId}")]
        public IActionResult answerPollApi(int pId, string answer,string userId)
        {
            if (pId != null && answer != null && userId != null)
            {
                PollAnswers answers = new PollAnswers()
                {
                    Answer = answer,
                    PollId = pId,
                    UserId = userId
                };
                dbContext.pollAnswers.Add(answers);
                dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}