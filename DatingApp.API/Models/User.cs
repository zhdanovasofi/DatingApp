using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public class User
    {
        public int Id {get;set;}

        public string Name { get; set; }

        public string Gender { get; set; }

        public byte [] PasswordHash {get; set;}

        public byte [] PasswordSalt {get; set;}

        public DateTime DateOfBirth { get;set; }

        public string KnonwAs{ get; set; }

        public DateTime Created { get; set;}

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<ServiceForClient> ServiceForClient { get; set; }
    }
}