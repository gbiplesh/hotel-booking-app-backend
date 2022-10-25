using System.Collections.Generic;

namespace HotelAppAPI.Models
{
    public class UserConstants
    {
        public static List<Users> Users = new List<Users>()
        {
            new Users() {Id = 1, Username = "john_admin", Email = "john.admin@email.com", Password="myPass_word123", FirstName="John", LastName = "Smith", Role = "Administrator"},
            new Users() {Id = 2, Username = "mary_admin", Email = "mary.user@email.com", Password="myPass_word456", FirstName="Mary", LastName = "Smith", Role = "Guest"},

        };
    }
}
