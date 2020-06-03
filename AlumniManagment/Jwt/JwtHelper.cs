using AlumniManagment.Data;
using AlumniManagment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AlumniManagment.Jwt
{
    public class JwtHelper
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;

        public JwtHelper(IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }
        public async Task<string> generatejsonwebtoken(ApplicationUser user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var credientials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Actort,user.Id),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            IList<string> roles = await userManager.GetRolesAsync(user);

            foreach(string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }

            var token = new JwtSecurityToken(
                issuer: configuration["jwt:issuer"],
                audience: configuration["jwt:issuer"],
                claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: credientials
                );

            var encodedtoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedtoken;
        }

        public bool ValidateToken(string Token,string role = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
            };
            IPrincipal principal;
            try
            {
                principal = tokenHandler.ValidateToken(Token, tokenValidationParameters, out validatedToken);
            }
            catch(Exception ex)
            {
                return false;
            }
            if(role!=null)
            {
                if(!principal.IsInRole(role))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
