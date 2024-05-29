using Booking.IRepos;
using Booking.Models;
using Booking.View_Model;
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

        public List<RoomsVM> GetAll()
        {
            var rooms = db.Rooms.Include(r => r.HotelBranch).Include(r => r.Booking)
                             .Select(r => new RoomsVM
                             {
                                 RoomNumber = r.RoomID,
                                 RoomType = r.RoomType,
                                 Price = r.Price,
                                 BookingId = r.BookingID,
                                 Description = r.Description,
                                 images = r.images,
                                 BranchName = r.HotelBranch.BranchName,
                                 CheckOutDate = r.Booking.CheckOutDate
                             })
                             .ToList();
            return rooms;
        }

        public RoomsVM GetById(int id)
        {
            var room = db.Rooms
                         .Where(r => r.RoomID == id)
                         .Select(r => new RoomsVM
                         {
                             RoomNumber = r.RoomID,
                             RoomType = r.RoomType,
                             Price = r.Price,
                             BookingId = r.BookingID,
                             Description = r.Description,
                             images = r.images,
                             BranchName = r.HotelBranch.BranchName,
                             BranchLocation = r.HotelBranch.BranchLocation,
                             NumberOfAdults = r.NumberOfAdults,
                             NumberOfChildren = r.NumberOfChildren
                         })
                         .SingleOrDefault();

            return room;
        }
    }
}
