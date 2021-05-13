using Curso.Api.Domain.Entities;
using Curso.Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Curso.Api.Application.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("autenticacao")]
        public async Task<ActionResult> Autenticacao([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro nos dados");

            if(user == null)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro nos dados");

            var result = await _loginService.FindByLogin(user);

            if (result == null)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro nos dados");

            return Ok(result);
        }
    }
}
