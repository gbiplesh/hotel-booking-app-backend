using System.ComponentModel.DataAnnotations;

namespace HotelAppAPI.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }
        public string RoomType { get; set; } = " ";
        public int Price { get; set; }
        public int Beds { get; set; }
        public int Available { get; set; }
        public string Image { get; set; }
    }
}
