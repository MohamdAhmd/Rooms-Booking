using System.Collections.Generic;

namespace Booking.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string PhoneNumber { get; set; }
        public int BookingCount { get; set; }

        public ICollection<BookingModel> Bookings { get; set; } = new List<BookingModel>();
    }
}
