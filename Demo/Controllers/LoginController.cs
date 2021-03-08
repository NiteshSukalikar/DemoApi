using AutoMapper;
using Demo.Repository;
using DemoData.Models;
using DemoData.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly DemoContext dbContext;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly IMapper mapper;

        public LoginController(DemoContext dbContext, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.dbContext = dbContext;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.mapper = mapper;
        }
        //[Authorize]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var user = mapper.Map<List<LoginVM>>(dbContext.tblLogin.ToList());
            return Ok(user);
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Login login)
        {
            RoleDataVM obj = new RoleDataVM();
            if (!this.dbContext.tblLogin.Any(a => a.Username == login.Username && a.Password == login.Password))
            {
                return Unauthorized();
            }

            var token = this.jwtAuthenticationManager.Autheticate(login.Username);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                var user = mapper.Map<LoginVM>(dbContext.tblLogin.Where(a => a.Username == login.Username).Single());
                obj.token = token;
                obj.data = user;
                return Ok(obj);
            }
        }
    }
}
