using System.Collections.Generic;

namespace Booking.Models
{
    public class HotelBranch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }

        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();
    }
}
