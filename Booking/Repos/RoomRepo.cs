using Booking.IRepos;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repos
{
    public class RoomRepo : IRoomRepo
    {
        dbContext db;
        public RoomRepo(dbContext _db)
        {
            db = _db;
        }

        public List<Room> GetAll()
        {
            return db.Rooms.Where(r => r.BookingID == null).ToList();
        }

        public Room GetById(int id)
        {
            return db.Rooms.FirstOrDefault(room => room.RoomID == id);
        }
    }
}
