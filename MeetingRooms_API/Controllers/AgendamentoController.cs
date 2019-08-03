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
    public class AgendamentosController : Controller
    {
        private readonly IAgendamentoRepository _AgendamentoRepositorio;
        public AgendamentosController(IAgendamentoRepository AgendamentoRepo)
        {
            _AgendamentoRepositorio = AgendamentoRepo;
        }


        /// <summary>
        /// Recupera todos os agendamentos
        /// </summary>
        /// <returns>Lista do Model Agendamento contendo todas as informações</returns>
        [HttpGet]
        public IEnumerable<Agendamento> GetAll()
        {
            return _AgendamentoRepositorio.GetAll();
        }

        /// <summary>
        /// Recupera um item de agendamento
        /// </summary>
        /// <param name="id">Identificador do Agendamento</param>
        /// <returns>Model do tipo Agendamento contendo todas as informações</returns>
        [HttpGet("{id}", Name = "GetAgendamento")]
        public IActionResult GetById(long id)
        {
            var Agendamento = _AgendamentoRepositorio.Find(id);
            if (Agendamento == null)
            {
                return NotFound();
            }
            return new ObjectResult(Agendamento);
        }

        /// <summary>
        /// Cria um agendamento por post de formulário
        /// </summary>
        /// <returns>Novo Model de Agendamento que foi registrado</returns>
        [HttpPost]
        public IActionResult Create([FromBody] Agendamento Agendamento)
        {
            if (Agendamento == null)
            {
                return BadRequest();
            }

            _AgendamentoRepositorio.Add(Agendamento);

            return CreatedAtRoute("GetAgendamento", new { id = Agendamento.Id }, Agendamento);
        }
    }
}