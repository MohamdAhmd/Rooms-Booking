using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class BookingModel
    {
        public int BookingID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("HotelBranch")]
        public int BranchID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalRooms { get; set; }
        public bool DiscountApplied { get; set; }
        public List<int> RoomNumbers { get; set; } = new List<int>();
     
        
        public Customer Customer { get; set; }
        public HotelBranch HotelBranch { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
