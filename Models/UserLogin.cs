using System.ComponentModel.DataAnnotations;

namespace HotelAppAPI.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }   
    }
}
