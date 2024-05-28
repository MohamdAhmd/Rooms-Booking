using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        [ForeignKey("Booking")]
        public int? BookingID { get; set; }
        public string RoomType { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public List<string>? images { get; set; } = new List<string>();


        public BookingModel Booking { get; set; }
    }
}
