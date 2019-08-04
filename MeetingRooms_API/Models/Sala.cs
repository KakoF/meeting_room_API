using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Agendamento Agendamento { get; set; }

    }
}
