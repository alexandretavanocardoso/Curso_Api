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
        public async Task<ActionResult> RecuperarUsuario(Guid id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Get(id));
        }

        [HttpPost("adicionarUsuario")]
        public async Task<ActionResult> AdicionarUsuario(UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Post(user));
        }

        [HttpPut("alterarUsuario")]
        public async Task<ActionResult> AlterarUsuario(UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Put(user));
        }

        [HttpPut("excluirUsuario")]
        public async Task<ActionResult> ExcluirUsuario(Guid id)
        {
            if (id == null)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Usuário não existe!");
            }

            return Ok(await _userService.Delete(id));
        }
    }
}
