using System.Collections.Generic;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContex _context;

        public Seed(DataContex context){
            this._context = context;
        }

        public void SeedUsers(){
            var userData = System.IO.File.ReadAllText("C:\\Users\\810052\\Desktop\\DatingApp\\DatingApp\\DatingApp.API\\Data\\UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users){
               byte []passwordHash, passwordSalt;
               CreatePasswordHash("password", out passwordHash, out passwordSalt);

               user.PasswordHash = passwordHash;
               user.PasswordSalt  = passwordSalt;
               user.Name  = user.Name.ToLower();

               _context.Users.Add(user);
            }
            _context.SaveChanges();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}