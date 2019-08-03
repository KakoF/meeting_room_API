using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Models
{
    public class AgendamentoDbContext : DbContext
    {
        public AgendamentoDbContext(DbContextOptions<AgendamentoDbContext> options)
                : base(options)
        {

        }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
