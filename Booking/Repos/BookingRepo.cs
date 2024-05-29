using Booking.IRepos;
using Booking.Models;

namespace Booking.Repos
{
    public class BookingRepo : IBookingRepo
    {
        dbContext db;
        public BookingRepo(dbContext _db)
        {
            db = _db;
        }

        public void create(BookingModel data)
        {
            db.Bookings.Add(data);
            db.SaveChanges();
            foreach (var roomNumber in data.RoomNumbers)
            {
                var room = db.Rooms.FirstOrDefault(r => r.RoomID == roomNumber);
                room.BookingID = data.BookingID;
            }
            db.SaveChanges();
        }
    }
}
