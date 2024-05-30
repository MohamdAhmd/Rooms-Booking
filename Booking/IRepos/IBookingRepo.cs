using Booking.View_Model;

namespace Booking.IRepos
{
    public interface IBookingRepo
    {
        CreateVM index();
        void create(BookingVM data);
    }
}
