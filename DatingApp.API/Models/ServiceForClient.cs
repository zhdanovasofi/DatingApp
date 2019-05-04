using System;

namespace DatingApp.API.Models
{
    public class ServiceForClient
    {
        public int Id { get; set; }

        public User User {get; set; }
        public int UserId { get; set;}

        public Price Price { get; set;}

        public int PriceId { get; set;}

        public DateTime ServiceDate {get;set;}

        public string Comment {get; set;}
    }
}