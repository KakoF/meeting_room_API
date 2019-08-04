using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRooms_API.Models;
using MeetingRooms_API.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRooms_API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;
        public UsuariosController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        /// <summary>
        /// Recupera um Usuário
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Model do tipo Usuário contendo todas as informações</returns>
        [Authorize]
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return new ObjectResult(usuario);
        }

        /// <summary>
        /// Recupera um Usuário
        /// </summary>
        /// <param name="id">Identificador do Usuário</param>
        /// <returns>Model do tipo Usuário contendo todas as informações</returns>
        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody] Usuario usuario)
        {
            var _usuario = _usuarioRepositorio.Autenticar(usuario.Email, usuario.Senha);

            if (_usuario == null)
                return Unauthorized();

            //_usuario.Senha = null;
            return new ObjectResult(_usuario);
        }

    }
}