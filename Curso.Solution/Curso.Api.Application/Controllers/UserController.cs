using Curso.Api.Domain.Entities;
using Curso.Api.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Curso.Api.Application.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("recuperarListaUsuario")]
        public async Task<ActionResult> RecuperarListaUsuario()
        {
            return Ok(await _userService.GetAll());
        }

       [HttpGet("recuperarUsuario")]
        public async Task<ActionResult> RecuperarUsuario([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Get(id));
        }

        [HttpPost("adicionarUsuario")]
        public async Task<ActionResult> AdicionarUsuario([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            var result = await _userService.Post(user);

            if(result != null)
            {
                return Created(new Uri(Url.Link("recuperarUsuario", new { 
                    id = result.Id}
                )), result);
            } else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Falta dados!");
            }
        }

        [HttpPut("alterarUsuario")]
        public async Task<ActionResult> AlterarUsuario([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            var result = await _userService.Put(user);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Falta dados!");
            }
        }

        [HttpDelete("excluirUsuario")]
        public async Task<ActionResult> ExcluirUsuario([FromRoute]  Guid id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Delete(id));
        }
    }
}
