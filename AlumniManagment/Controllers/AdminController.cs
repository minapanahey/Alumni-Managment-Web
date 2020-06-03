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
using AlumniManagment.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace AlumniManagment.Controllers
{
    public class AdminController : Controller
    {
        HttpClient client;
        private readonly Authorize authorize;

        public AdminController(Authorize authorize)
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

        //[AuthorizeControllerWithToken("admin")]
        public IActionResult createEvent()
        {
            if (!authorize.AuthorizeUser("admin"))
            {
                return RedirectToAction("login", "user");
            }
            return View();
        }

        //[AuthorizeControllerWithToken("admin")]
        [HttpPost]
        public async Task<ActionResult> createEvent(EventViewModel model)
        {
            if (!authorize.AuthorizeUser("admin"))
            {
                return RedirectToAction("login", "user");
            }

            if (model.calendarDto.start > model.calendarDto.end)
            {
                ModelState.AddModelError("","End date can't be earlier or same as start date");
                
            }
            if (model.calendarDto.start < DateTime.Now)
            {
                ModelState.AddModelError("", "Enter A Valid Start Time");
            }
            if (ModelState.IsValid)
            {
                using (client)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Clear();
                    //HTTP POST
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/event/", model);


                    if (response.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("index", "home");
                    }

                    //String result = await response.Content.ReadAsStringAsync();
                    //JObject json = JObject.Parse(result);
                    //ModelState.AddModelError("Error", json["ModelState"][""][0].ToString());
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("admin/CreatePoll")]
        public IActionResult CreatePoll()
        {
            if (!authorize.AuthorizeUser("admin"))
            {
                return RedirectToAction("login", "user");
            }
            return View();
        }

        [HttpPost]
        [Route("admin/CreatePoll")]
        public async Task<IActionResult> CreatePoll(Polls model)
        {
            if (!authorize.AuthorizeUser("admin"))
            {
                return RedirectToAction("login", "user");
            }
            if (ModelState.IsValid)
            {
                using (client)
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                    //HTTP Get
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                        "api/polls/CreatePollApi/", model);

                    if (response.IsSuccessStatusCode == true)
                    {
                        TempData["msg"] = "Poll Created Successfully";
                        return RedirectToAction("createpoll", "admin");
                    }

                    return Content("Some Internal Error Occur");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> teachers()
        {
            if (!authorize.AuthorizeUser("admin"))
            {
                //return RedirectToAction("login", "user");
            }
            
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                //HTTP Get
                HttpResponseMessage response = await client.GetAsync("api/admin/teachersApi");

                if (response.IsSuccessStatusCode == true)
                {
                    TeachersViewModel viewModel = response.Content.ReadAsAsync<TeachersViewModel>().Result;
                    
                    return View(viewModel);
                }
                return Content("Some Internal Error Occur");
            }
        }

        public async Task<IActionResult> addNewTeacherProfile(AddNewTeacherViewModel viewModel)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(viewModel.Picture.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            if (ModelState.IsValid)
            {
                using (client)
                {

                    //HTTP Get
                    viewModel.Picture = null;
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/admin/addNewTeacherApi", viewModel);
                    if (response.IsSuccessStatusCode == true)
                    {

                        return RedirectToAction("teachers");
                    }
                    return Content("Some Internal Error Occur");
                }
            }
            return RedirectToAction("teachers", "admin");
        }

        public IActionResult index()
        {
            return View();
        }

    }
}