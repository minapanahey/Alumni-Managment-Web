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
using AlumniManagment.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlumniManagment.Controllers.api
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public AdminController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [Route("api/admin/teachersApi")]
        [AllowAnonymous]
        public IActionResult teachersApi()
        {
            List<Teacher> teachers = dbContext.teachers.Include(t => t.Department).ToList();
            TeachersViewModel viewModel = new TeachersViewModel()
            {
                Teachers = teachers,
                AddNewTeacherViewModel = new AddNewTeacherViewModel()
                {
                    departments = dbContext.departments.Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    }).ToList()
                }
            };
            return Ok(viewModel);
        }
        [Route("api/admin/addNewTeacherApi")]
        [AllowAnonymous]
        public IActionResult addNewTeacherApi([FromBody]AddNewTeacherViewModel viewModel)
        {

            if (ModelState.IsValid) 
            {
                Teacher t = new Teacher
                {
                    DepartmentId = viewModel.dept,
                    Name = viewModel.Name,
                    Specialization = viewModel.Specialization,
                };
                dbContext.teachers.Add(t);
                dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }

    }
}
