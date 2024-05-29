using System.Collections.Generic;

namespace Booking.Models
{
    public class HotelBranch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }

        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();
        // One-to-many relationship with Room
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
