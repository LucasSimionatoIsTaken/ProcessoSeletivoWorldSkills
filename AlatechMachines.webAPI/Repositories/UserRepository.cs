using AlatechMachines.webAPI.Interfaces;
using AlatechMachines.webAPI.Domains;
using AlatechMachines.webAPI.Contexts;
using System.Linq;
using AlatechMachines.webAPI.utils;

namespace AlatechMachines.webAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AlatechDbContext _ctx = new AlatechDbContext();
        private readonly Criptography criptography = new Criptography();
        public bool DeleteUserToken(int userId)
        {
            User user = _ctx.Users.Find(userId);

            user.AccessToken = null;

            _ctx.Users.Update(user);

            _ctx.SaveChanges();

            return true;
        }

        public User FindByEmailAndPassword(string username, string password)
        {
            User user = _ctx.Users.FirstOrDefault(x => x.Username == username);

            bool pass = criptography.VerificarHash(user.Password, password);

            if (pass)
            {
                return user;
            }

            return null;
        }

        public User FindById(int id)
        {
            return _ctx.Users.Find(id);
        }

        public void SaveToken(string token, int id)
        {
            User user = _ctx.Users.Find(id);

            user.AccessToken = token;

            _ctx.Users.Update(user);

            _ctx.SaveChanges();
        }

        public bool VerifyToken(string token, int id)
        {
            User user = _ctx.Users.Find(id);

            return user.AccessToken == token;
        }
    }
}
