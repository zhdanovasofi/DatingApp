using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private DataContex _context;

        public AuthRepository(DataContex context)
        {
            _context = context;
        }

        public async Task<User> Register(User User, string password)
        {
            byte [] passwordHash;
            byte [] passwordSalt;
            CreatePasswordHash(password,out passwordHash, out passwordSalt);
            
            User.PasswordHash = passwordHash;
            User.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            return User;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA1())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        public async Task<User> Login(string username, string password)
         {

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == username);

            if (user==null){
                return null;
            }
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)){
                return null;
            }

            return user;
         }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA1())
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i=0; i<computedHash.Length; i++){
                    if (computedHash[i]!=passwordHash[i])
                        return false;
                }
                return true;
            }

            
        }

        public async Task<bool> UserExists(string username){
            if (await _context.Users.AnyAsync(x => x.Name == username))
                return true;
                
            return false;
        }

    }
}