using Booking.Models;

namespace Booking.IRepos
{
    public interface IRoomRepo
    {
        List<Room> GetAll();
        Room GetById(int id);
    }
}
