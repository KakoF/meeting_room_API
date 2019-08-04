using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepositorio;
        public TokenController(IConfiguration configuration, IUsuarioRepository usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
            _configuration = configuration;
        }

        /// <summary>
        /// Gera o Token para o usuário
        /// </summary>
        /// <param name="email">E-mail do Usuário</param>
        /// <param name="senha">Senha do Usuário</param>
        /// <returns>Objeto Token tipo JWT</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Usuario request)
        {
            request.Senha = _usuarioRepositorio.Decrypt(request.Senha);
            request = _usuarioRepositorio.Autenticar(request.Email, request.Senha);
            if (request != null)
            {
                var claims = new[]
                {
                     new Claim(ClaimTypes.Name, request.Id.ToString())
                };

                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "access_token_meeting_rooms",
                     audience: "access_token_meeting_rooms",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                request.Token = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            return BadRequest("Credenciais inválidas...");
        }
    }
}