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
    [Authorize]
    public class SalasController : Controller
    {
        private readonly ISalaRepository _SalaRepositorio;
        public SalasController(ISalaRepository SalaRepo)
        {
            _SalaRepositorio = SalaRepo;
        }

        /// <summary>
        /// Recupera todas as salas
        /// </summary>
        /// <returns>Lista do Model Sala contendo todas as informações</returns>
        [HttpGet]
        public IEnumerable<Sala> GetAll()
        {
            return _SalaRepositorio.GetAll();
        }

        /// <summary>
        /// Recupera um item de sala
        /// </summary>
        /// <param name="id">Identificador da Sala</param>
        /// <returns>Model do tipo Agendamento contendo todas as informações</returns>
        [HttpGet("{id}", Name = "GetSala")]
        public IActionResult GetById(long id)
        {
            var Sala = _SalaRepositorio.Find(id);
            if (Sala == null)
            {
                return NotFound();
            }
            return new ObjectResult(Sala);
        }
    }
}