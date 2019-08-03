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
        /// Recupera o Usuário ao tentar se Autenticar e já valida o Token
        /// </summary>
        /// <param name="email">E-mail do Usuário</param>
        /// <param name="senha">Senha do Usuário</param>
        /// <returns>Objeto do Tipo Usuário com o Token</returns>
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
                     //new Claim(ClaimTypes.Name, request.Nome)
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                     issuer: "access_token_meeting_rooms",
                     audience: "access_token_meeting_rooms",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                request.Token = new JwtSecurityTokenHandler().WriteToken(token);
                //request.Senha = null;
                //return new ObjectResult(request);
                //return Ok(new{ request, sendToken });
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            return BadRequest("Credenciais inválidas...");
        }
    }
}