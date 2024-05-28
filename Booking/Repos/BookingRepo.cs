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
        }
    }
}
