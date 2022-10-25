using HotelAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace HotelAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are an {currentUser.Role}");
        }

        [HttpGet("Guests")]
        [Authorize(Roles = "Guest")]
        public IActionResult GuestsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, you are a {currentUser.Role}");
        }

        [HttpGet("AdminsAndGuests")]
        [Authorize(Roles = "Administrator, Guest")]
        public IActionResult AdminsAndGuestsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.FirstName}, Welcome our {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, You are on public property."); 
        }

        private Users GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity; 
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new Users
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    FirstName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null; 
        }

        //private IActionResult Routing()
        //{
        //    new Users GetCurrentUser();
        //    return AdminsAndGuestsEndpoint(); 
        //}
    }
}
