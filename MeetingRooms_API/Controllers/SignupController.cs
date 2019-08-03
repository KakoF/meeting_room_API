using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MeetingRooms_API.Models;
using MeetingRooms_API.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MeetingRooms_API.Controllers
{
    [Route("api/[controller]")]
    public class SignupController : Controller
    {
        private const int SaltSize = 16;  
        private const int KeySize = 32;

        private readonly IUsuarioRepository _usuarioRepositorio;
        public SignupController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="usuario">Espera o objeto do tipo Usuário preenchido</param>
        /// <returns>Objeto novo Usuário Cadastrado</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestSignup([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            usuario.Senha = _usuarioRepositorio.HashSenha(usuario.Senha);
           _usuarioRepositorio.Add(usuario);
            return new ObjectResult(usuario);
        }




    }
}