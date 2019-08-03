using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Sala_Id { get; set; }
        [ForeignKey("Sala_Id")]
        public Sala Sala { get; set; }
        public DateTime Periodo { get; set; }
    }
}
