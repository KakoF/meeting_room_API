using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Models
{
    public class SalaDbContext : DbContext
    {
        public SalaDbContext(DbContextOptions<SalaDbContext> options)
                : base(options)
        {

        }

        public DbSet<Sala> Salas { get; set; }
    }
}
