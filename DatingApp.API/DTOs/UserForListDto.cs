using System;

namespace DatingApp.API.DTOs
{
    public class UserForListDto
    {
          public int Id {get;set;}

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age{ get;set; }

        public string KnonwAs{ get; set; }

        public string PhotoUrl {get; set;}


    }
}