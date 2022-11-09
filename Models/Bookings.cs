using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAppAPI.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        public string RoomType { get; set; }
        public string FullName { get; set; }
        public int RoomQuantity { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckIn { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckOut { get; set; }
        public int Price { get; set; }


    }
}
