using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class Price
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public decimal PriceTag {get; set; }

        public string Description { get; set;}

        public User User {get; set;}

        public int UserId {get; set;}
    }
}