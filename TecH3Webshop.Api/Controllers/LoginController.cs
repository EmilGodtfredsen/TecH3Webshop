using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecH3Webshop.Api.Domain;
using TecH3Webshop.Api.Services;

namespace TecH3Webshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // GET /api/login

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var logins = await _loginService.GetAll();
                if (logins == null)
                {
                    return Problem("Returned null, unexpected behavior!");
                }
                else if (logins.Count == 0)
                {
                    return NoContent();
                }
                return Ok(logins);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET (email) /api/login

        [HttpGet("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            try
            {
                var login = await _loginService.GetByEmail(email);
                if (login == null)
                {
                    return NotFound();
                }
                return Ok(login);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST /api/login

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create(Login login)
        {
            try
            {
                if(login == null)
                {
                    return BadRequest("Failed to create login!");
                }
                var newLogin = await _loginService.Create(login);
                return Ok(newLogin);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            } 
        }

        // PUT (email) /api/login

        [HttpPut("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Update([FromRoute] string email, Login login)
        {
            try
            {
                var updateLogin = await _loginService.Update(email, login);
                if(updateLogin == null)
                {
                    return NotFound("It was not possible to edit this login! Not Found");
                }
                return Ok(updateLogin);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE (id) /api/login

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deleteLogin = await _loginService.Delete(id);
                if(deleteLogin == null)
                {
                    return NotFound("User with id: " + id + " does not exist!");
                }
                return Ok(deleteLogin);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            } 
        }
    }
}
