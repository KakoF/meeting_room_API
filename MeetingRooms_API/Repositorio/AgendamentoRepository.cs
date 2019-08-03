using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AgendamentoDbContext _contexto;

        public AgendamentoRepository(AgendamentoDbContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(Agendamento agendamento)
        {
            _contexto.Agendamentos.Add(agendamento);
            _contexto.SaveChanges();
        }

        public Agendamento Find(long id)
        {
            return _contexto.Agendamentos.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Agendamento> GetAll()
        {
            return _contexto.Agendamentos.ToList();
        }
    }
}