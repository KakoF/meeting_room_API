using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Models
{
        [Table("Usuarios")]
        public class Usuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Senha { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
    }
}