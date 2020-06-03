using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AlumniManagment.AuthorizeControllerWithToken;
using AlumniManagment.Models;
using AlumniManagment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlumniManagment.Controllers
{
    public class PollsController : Controller
    {

        HttpClient client;
        private readonly Authorize authorize;
        private readonly UserServices userServices;

        public PollsController(Authorize authorize,UserServices userServices)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337/");
            this.authorize = authorize;
            this.userServices = userServices;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token").ToString());
            }
        }
        public async Task<IActionResult> Index()
        {
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Clear();
                //HTTP Get
                HttpResponseMessage response = await client.GetAsync("api/polls/getAllPolls/"+userServices.getLoggedInUserId());

                if (response.IsSuccessStatusCode == true)
                {
                    List<Polls> polls = response.Content.ReadAsAsync<List<Polls>>().Result;
                    return View(polls);
                }

                return Content("Some Internal Error Occur");
            }
        }

        public async Task<IActionResult> answer(int pId, string answer)
        {
            if(pId !=null && answer !=null)
            {
                using(client)
                {
                    string userId = HttpContext.Session.GetString("userId");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                    //HTTP Get
                    HttpResponseMessage response = await client.GetAsync(
                        "api/polls/answerPollApi/"+pId+"/"+answer+"/"+userId);

                    if (response.IsSuccessStatusCode == true)
                    {
                        TempData["msg"] = "Poll Answer Submitted Successfully";
                    }
                }
            }
            return RedirectToAction("index");
        }

    }
}