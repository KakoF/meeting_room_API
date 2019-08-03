using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public interface ISalaRepository
    {
       
        IEnumerable<Sala> GetAll();

        Sala Find(long id);
    }
}