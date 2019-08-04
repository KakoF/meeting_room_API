using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);

        Usuario Autenticar(string usuario, string senha);

        Usuario Find(long id);

        string HashSenha(string senha);

        string Decrypt(string senha);
    }
}