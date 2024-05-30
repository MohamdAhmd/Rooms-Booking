using Booking.Models;

namespace Booking.View_Model
{
    public class BookingVM
    {
        // Customer information
        public string CustomerName { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }

        // Booking details
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string BranchName { get; set; }
        public int TotalRooms { get; set; }

        // List of rooms
        public List<int> RoomNumber { get; set; } = new List<int>();

        // Discount indicator
        public bool DiscountApplied { get; set; }
    }
}
