using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public class SalaRepository : ISalaRepository
    {
        private readonly SalaDbContext _contexto;

        public SalaRepository(SalaDbContext ctx)
        {
            _contexto = ctx;
        }
        public Sala Find(long id)
        {
            return _contexto.Salas.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Sala> GetAll()
        {
            return _contexto.Salas.ToList();
        }
    }
}