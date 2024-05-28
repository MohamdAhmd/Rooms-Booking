using Booking.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class HotelController : Controller
    {
        IRoomRepo RoomRepo;
        public HotelController(IRoomRepo _roomRepo)
        {
            RoomRepo = _roomRepo;  
        }
        public IActionResult Index()
        {
            var rooms = RoomRepo.GetAll();
            return Json(rooms);
        }

        public IActionResult Details(int id)
        {
            var room = RoomRepo.GetById(id);
            return Json(room);
        }

    }
}
