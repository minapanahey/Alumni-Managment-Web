using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlumniManagment.Data;
using AlumniManagment.Models;
using AlumniManagment.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AlumniManagment.Jwt;
using AlumniManagment.ViewModels;

namespace AlumniManagment.Controllers.api
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly JwtHelper jwtHelper;

        public AccountController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            JwtHelper jwtHelper)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtHelper = jwtHelper;
        }

        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            string regNo = model.season + "-" + model.department + "-" + model.roll;

            bool regAlreadyExist = dbContext.Users.Any(u => u.regNo == regNo);
            if (regAlreadyExist)
            {
                ModelState.AddModelError("", "Registration No Already Exist");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                DOB = model.DOB,
                firstName = model.firstName,
                lastName = model.lastName,
                profilePicture = model.profilePictureName,
                facebookLink = model.facebookLink,
                instagramLink = model.instagramLink,
                twitterLink = model.twitterLink,
                regNo = regNo
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var privacy = new AccountPrivacy()
                {
                    emailIsPublic = false,
                    instagramIsPublic = false,
                    twitterIsPublic = false,
                    facebookIsPublic = false,
                    phoneIsPublic = false,
                    userId = user.Id
                };
                dbContext.accountPrivacy.Add(privacy);
                dbContext.SaveChanges();
                return Ok();
            }
            foreach(var err in result.Errors)
            {
                ModelState.AddModelError("",err.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                string regNo = model.season + "-" + model.department + "-" + model.roll;
                ApplicationUser user = dbContext.Users.SingleOrDefault(u => u.regNo == regNo);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.password, model.rememberMe, false);
                    if (result.Succeeded)
                    {
                        var token = await jwtHelper.generatejsonwebtoken(user);
                        return Ok(token);
                    }
                }
                ModelState.AddModelError("", "Invalid Reg or Password");
                return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }
        
        [Route("asd")]
        [Authorize]
        public async Task<IActionResult> asd([FromForm]RegisterViewModel model)
        {
            return Ok();
        }
    }

}