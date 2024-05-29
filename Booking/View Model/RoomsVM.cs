using Booking.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Booking.View_Model
{
    public class RoomsVM
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }
        public int? BookingId { get; set; }
        public string Description { get; set; }
        public List<string> images { get; set; } = new List<string>(); 
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }

        public DateTime? CheckOutDate { get; set; }

    }
}
