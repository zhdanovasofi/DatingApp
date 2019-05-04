using System;
using System.Collections.Generic;
using DatingApp.API.Models;

namespace DatingApp.API.DTOs
{
    public class UserFotDetailDto
    {
        public int Id {get;set;}

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get;set; }

        public string KnonwAs{ get; set; }

        public DateTime Created { get; set;}

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string PhotoUrl {get; set; }
        public ICollection<Photo> Photos { get; set; }

    }
}