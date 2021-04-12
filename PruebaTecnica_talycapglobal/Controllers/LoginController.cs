using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica_talycapglobal.Authorization;
using PruebaTecnica_talycapglobal.Data.Model;
using PruebaTecnica_talycapglobal.Service.Server.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica_talycapglobal.Controllers
{
    /// <summary>
    /// Controlador LoginController
    /// </summary>
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly IJwt _jwt;
        /// <summary>
        /// Controller constructor
        /// </summary>
        public LoginController(ILoginService service, IJwt jwt)
        {
            _service = service;
            _jwt = jwt;
        }
        /// <summary>
        /// Funcion encargada de realizar la validaciones de credenciales en el sistema
        /// </summary>
        /// <param name="userName">Nombre de usuarios</param>
        /// <param name="passWord">Password</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> GetLogin(string userName, string passWord)
        {
            var user = await _service.Login(userName, passWord);
            
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_jwt.GetToken(user));
        }
        /// <summary>
        /// Funcion que se encarga de devolver la cantidad de usuarios en el sistema
        /// </summary>
        /// <returns>Cantidad de usuarios</returns>
        [Authorize]
        [HttpGet("UsersCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        public async Task<ActionResult<int>> GetUsersCount()
        {
            var user = await _service.UsersCount();
            return Ok(user);
        }
    }
}
