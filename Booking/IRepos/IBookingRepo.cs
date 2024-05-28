using Booking.Models;

namespace Booking.IRepos
{
    public interface IBookingRepo
    {
        void create(BookingModel data);
    }
}
