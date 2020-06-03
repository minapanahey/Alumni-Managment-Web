using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using AlumniManagment.Models;
using Newtonsoft.Json.Linq;
using AlumniManagment.Models.ViewModels;
using AlumniManagment.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AlumniManagment.ViewModels.Account;
using AlumniManagment.Services;
using Microsoft.AspNetCore.Hosting;
using RestSharp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json;
using AlumniManagment.AuthorizeControllerWithToken;

namespace AlumniManagment.Controllers
{
    public class UserController : Controller
    {
        HttpClient client;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly Authorize authorize;
        private readonly UserServices userServices;

        public UserController(
            IHostingEnvironment hostingEnvironment,
            Authorize authorize,
            UserServices userServices)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337/");
            this.hostingEnvironment = hostingEnvironment;
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

        // GET: User
        //public ActionResult Index()
        //{
        //    return Content(User.Identity.IsAuthenticated.ToString());
            
        //}

        [AllowAnonymous]
        public ViewResult register()
        {
            RegisterViewModel model = new RegisterViewModel()
            {
                seasons = userServices.GetSeasons(),
                departments = userServices.GetDepartmetns(),
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("user/register")]
        public async Task<ActionResult> registerAsync(RegisterViewModel model)
        {
            // if validation fails at any point these field should not be empty
            model.seasons = userServices.GetSeasons();
            model.departments = userServices.GetDepartmetns();
            
            String picUniqueName = "";

            if (model.profilePicture != null)
            {
                picUniqueName = string.Format("{0}-{1}{2}"
                            , Path.GetFileNameWithoutExtension(model.profilePicture.FileName)
                            , Guid.NewGuid().ToString("N")
                            , Path.GetExtension(model.profilePicture.FileName));

            }
            else
            {
                ModelState.AddModelError("", "Please Select A Profile Picture ");
            }
            // because in profile picture file wrapper object is stored not string name

            if (!ModelState.IsValid)
            {
                return View("register", model);
            }

            using (client)
            {
                var client2 = new RestClient("https://localhost:44337/api/Account/Register");
                var request = new RestRequest(Method.POST);
                model.profilePictureName = picUniqueName;
                request.AddObject(model);
                //request.AlwaysMultipartFormData = true;
                //request.AddFile("profilePicture", "T3WsmCaK.jpg");
                IRestResponse response = client2.Execute(request);

                //HTTP POST
                if (response.IsSuccessful == true)
                {
                    // Move Uploded Picture
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UserImages");
                    string filePath = Path.Combine(uploadsFolder, picUniqueName);
                    model.profilePictureName = picUniqueName;
                    ////model.profilePicture.CopyTo(new FileStream(filePath, FileMode.Create));
                    return RedirectToAction("index", "home");
                }
                string result = response.Content;
                JObject json = JObject.Parse(result);

                var x = json[""][0].Count();
                foreach(var err in json[""])
                {
                    ModelState.AddModelError("", err.ToString());
                }
                return View("register", model);
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("user/login")]
        public ViewResult login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                seasons = userServices.GetSeasons(),
                departments = userServices.GetDepartmetns(),
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("user/login")]
        public async Task<ActionResult> loginAsync(LoginViewModel model)
        {
            model.seasons = userServices.GetSeasons();
            model.departments = userServices.GetDepartmetns();
            if (!ModelState.IsValid)
            {
                return View("login", model);
            }
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //HTTP Get

                HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/Login", model);


                if (response.IsSuccessStatusCode == true)
                {
                    HttpContext.Session.SetString("token", await response.Content.ReadAsStringAsync());
                    
                    var handler = new JwtSecurityTokenHandler();
                    var token =handler.ReadJwtToken(HttpContext.Session.GetString("token"));
                    List<Claim> claims = token.Claims.ToList();
                    HttpContext.Session.SetString("userName",claims.ElementAt(1).Value);
                    HttpContext.Session.SetString("userEmail",claims.ElementAt(1).Value);
                    HttpContext.Session.SetString("userId", claims.ElementAt(2).Value);

                    List<string> roles = claims.Where(c => c.Type == ClaimTypes.Role).Select(c=>c.Value).ToList();
                    HttpContext.Session.SetString("roles", JsonConvert.SerializeObject(roles));
                    
                    return RedirectToActionPermanent("index","home");
                }
                var result = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);
                foreach (var err in json[""])
                {
                    ModelState.AddModelError("", err.ToString());
                };

                return View("login", model);
            }

        }

        [HttpPost]
        public ActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "home");
        }

        public async Task<ActionResult> settings()
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            String userId = HttpContext.Session.GetString("userId").ToString();

            using (client)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //HTTP Get
                HttpResponseMessage response = await client.GetAsync("api/profile/" +userId);

                if (response.IsSuccessStatusCode == true)
                {
                    UserDto user = response.Content.ReadAsAsync<UserDto>().Result;
                    AccountPrivacyDto privacyDto = null;

                    HttpResponseMessage response2 = await client.GetAsync("api/profile/privacy/" +userId);

                    if(response2.IsSuccessStatusCode == true)
                    {
                        privacyDto = response2.Content.ReadAsAsync<AccountPrivacyDto>().Result;
                    }
                    SettingViewMolde settingView = new SettingViewMolde()
                    {
                        user = user,
                        privacy = privacyDto
                    };
                    return View(settingView);
                }

                String result = await response.Content.ReadAsStringAsync();
                //JObject json = JObject.Parse(result);

                // Add errors to model state the return 
                return View(result);
            }
        }

        [HttpPost]
        public async Task<ActionResult> settings(SettingViewMolde model)
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            if (!ModelState.IsValid)
            {
                return View("settings",model);
            }

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            client.DefaultRequestHeaders.Accept.Clear();
            String Uri = "api/profile/" + HttpContext.Session.GetString("userId").ToString();
            HttpResponseMessage response = await client.PutAsJsonAsync(Uri, model);

            String result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == true)
            {
                HttpContext.Session.SetString("userEmail", model.user.Email);
                return View("settings",model);
            }
            ModelState.AddModelError("","Information Can't be updated due to some issue");
            return View("settings",ModelState);
        }

        public async Task<ActionResult> registeredEvents()
        {
            if (!authorize.AuthorizeUser())
            {
                return RedirectToAction("login", "user");
            }
            using (client)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                string userId = HttpContext.Session.GetString("userId").ToString();
                //HTTP Get
                HttpResponseMessage response = await client.GetAsync("api/profile/registeredEvents/"+userId);

                if (response.IsSuccessStatusCode == true)
                {
                    IEnumerable<eventRegistrationDto> registeredEvents = response.Content.ReadAsAsync<IEnumerable<eventRegistrationDto>>().Result;

                    return View(registeredEvents);
                }

                return Content("Some Internal Error Occur");
            }
        }

    }
}