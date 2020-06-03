using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using AlumniManagment.Models.ViewModels;
using AlumniManagment.Dtos;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using AlumniManagment.AuthorizeControllerWithToken;
using AlumniManagment.Models;

namespace AlumniManagment.Controllers
{
    public class EventController : Controller
    {
        HttpClient client;
        private readonly Authorize authorize;

        public EventController(Authorize authorize)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337/");
            this.authorize = authorize;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token").ToString());
            }
        }

        // GET: Event
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Route("event/all")]
        public async Task<IActionResult> all()
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();

                //HTTP Get
                string userId = HttpContext.Session.GetString("userId");
                HttpResponseMessage response = await client.GetAsync("api/allEvents/" + userId);

                if (response.IsSuccessStatusCode == true)
                {
                    IEnumerable<EventDto> events = response.Content.ReadAsAsync<IEnumerable<EventDto>>().Result;
                    return View(events);
                }

                return Content("Some Internal Error Occur");
            }
        }

        // Register Usr To Event
        [Route("event/register/{eventId}")]
        public async Task<ActionResult> register(int eventId)
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //HTTP Get
                HttpResponseMessage response = await client.GetAsync("api/event/"+eventId);

                if (response.IsSuccessStatusCode == true)
                {
                    EventDto events = response.Content.ReadAsAsync<EventDto>().Result;
                    TempData["title"] = events.title;
                    TempData["registrationFee"] = events.registrationFee;
                    TempData["dinnerFee"] = events.dinnerFee;
                    TempData["shirtFee"] = events.shirtFee;
                    TempData["eventId"] = events.id;

                    return View();
                }

                return Content("Some Internal Error Occur");
            }
        }

        [Route("event/register/{eventId}")]
        [HttpPost]
        public async Task<ActionResult> register(int eventId, eventRegistrationDto model)
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //HTTP Get
                string userId = HttpContext.Session.GetString("userId");
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/event/register/" + eventId+"/"+userId,model);

                if (response.IsSuccessStatusCode == true)
                {

                    return RedirectToAction("index", "home", null);
                }

                return Content("Some Internal Error Occur");
            }
        }
    
        
    }
}