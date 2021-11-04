using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaCore.Models.DAO;
using PracticaCore.Models.ObjectValues;
using PracticaCore.Models.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public IActionResult Get([FromBody]AuthRequest model)
        {
            DataResponse data = new DataResponse();
            var response = _userService.Auth(model);
            if (response == null)
            {
                data.Success = 0;
                data.Message = "Usuario incorrecto";
                return BadRequest(data);
            }
            data.Success = 1;
            data.Data = response;
                
            return Ok(data);
        }
    }
}
