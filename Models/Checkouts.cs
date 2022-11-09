using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAppAPI.Models
{
    public class Checkouts
    {
        [Key]
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }
        public string VerificationID { get; set; }
    }
}
