using ArtSofteStaff.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff.Controllers
{
   
        [Authorize]
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private IUserService _userService;

            public AuthController(IUserService userService)
            {
                _userService = userService;
            }

            [AllowAnonymous]
            [HttpPost]
            public async Task<IActionResult> Authenticate([FromBody] Person model)
            {
                var user = await _userService.Authenticate(model.Login, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Некорректный логин или пароль" });

                return Ok(user);
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var users = await _userService.GetAll();
                return Ok(users);
            }
        }
    
}
