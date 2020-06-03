using AlumniManagment.Jwt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlumniManagment.AuthorizeControllerWithToken
{
    public class Authorize
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly JwtHelper jwtHelper;

        public Authorize(IHttpContextAccessor httpContextAccessor, JwtHelper jwtHelper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.jwtHelper = jwtHelper;
        }
        public bool AuthorizeUser(string role = null)
        {
            string Token = httpContextAccessor.HttpContext.Session.GetString("token");
            if(Token != null)
            {
                bool result = jwtHelper.ValidateToken(Token,role);
                if(!result)
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                }
                return result;
            }
            return false;
        }
    }
}
