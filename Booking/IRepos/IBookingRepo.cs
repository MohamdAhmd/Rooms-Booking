using Booking.View_Model;

namespace Booking.IRepos
{
    public interface IBookingRepo
    {
        void create(BookingVM data);
    }
}
