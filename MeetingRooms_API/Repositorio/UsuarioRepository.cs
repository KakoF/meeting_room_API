using MeetingRooms_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeetingRooms_API.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        private readonly UsuarioDbContext _contexto;

        public UsuarioRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }


        public string HashSenha(string senha)
        {
            byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(senha);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

       

        public void Add(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }


        public Usuario Find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public Usuario Autenticar(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            password = this.HashSenha(password.ToLower());
            var user = _contexto.Usuarios.SingleOrDefault(x => x.Email == email && x.Senha == password);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            //     return null;

            // authentication successful
            return user;
        }

        public void Remove(long id)
        {
            var entity = _contexto.Usuarios.First(u => u.Id == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }

        public string Decrypt(string senha)
        {
            byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(senha);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}