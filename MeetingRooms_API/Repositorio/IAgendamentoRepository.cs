using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public interface IAgendamentoRepository
    {
        void Add(Agendamento agendamento);
        IEnumerable<Agendamento> GetAll();
        Agendamento Find(long id);
    }
}