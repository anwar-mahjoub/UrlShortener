using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Context;
using UrlShortener.Dto;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UrlShortenerContext context;

        public UsersController(UrlShortenerContext context)
        {
            this.context = context;
        }

        // POST: api/Users
        [HttpPost("register")]
        public async Task<int> Post([FromQuery]string email)
        {
            User user= new User()
            {
                Email = email,
                CreationDate = DateTime.Now,
            };
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();
            return user.UserID;
        }

        [HttpPost("login")]
        public void Login([FromBody] AuthenticationDto input)
        {

        }

        [HttpPost("logout")]
        public void Logout()
        {
        }
        
    }
}
