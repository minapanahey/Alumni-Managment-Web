using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlumniManagment.Services
{
    public class UserServices
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserServices(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<SelectListItem> GetSeasons()
        {
            List<SelectListItem> seasons = new List<SelectListItem>();
            SelectListItem season = new SelectListItem()
            {
                Text = "Fa19",
                Value = "fa19"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa18",
                Value = "fa18"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa17",
                Value = "fa17"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa16",
                Value = "fa16"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa15",
                Value = "fa15"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa14",
                Value = "fa14"
            };
            seasons.Add(season);
            season = new SelectListItem()
            {
                Text = "Fa13",
                Value = "fa13"
            };
            seasons.Add(season);

            season = new SelectListItem()
            {
                Text = "Fa12",
                Value = "fa12"
            };
            seasons.Add(season);

            return seasons;
        }

        public IEnumerable<SelectListItem> GetDepartmetns()
        {
            List<SelectListItem> departments = new List<SelectListItem>();
            SelectListItem department = new SelectListItem()
            {
                Text = "BDS",
                Value = "bds"
            };
            departments.Add(department);

            department = new SelectListItem()
            {
                Text = "BSE",
                Value = "bse"
            };
            departments.Add(department);

            department = new SelectListItem()
            {
                Text = "BDS",
                Value = "bds"
            };
            departments.Add(department);

            department = new SelectListItem()
            {
                Text = "BCS",
                Value = "bcs"
            };
            departments.Add(department);

            department = new SelectListItem()
            {
                Text = "BCE",
                Value = "bce"
            };
            departments.Add(department);

            department = new SelectListItem()
            {
                Text = "BBA",
                Value = "bba"
            };
            departments.Add(department);

            return departments;;
        }

        public bool isLoggedIn()
        {
            if(httpContextAccessor.HttpContext.Session.GetString("userId") != null)
            {
                return true;
            }
            return false;
        }

        public string getLoggedInUserId()
        {
            if(isLoggedIn())
            {
                return httpContextAccessor.HttpContext.Session.GetString("userId");
            }
            return null;
        }
    }
}