using Booking.Models;
using Booking.View_Model;

namespace Booking.IRepos
{
    public interface IRoomRepo
    {
        List<RoomsVM> GetAll();
        RoomsVM GetById(int id);
    }
}
