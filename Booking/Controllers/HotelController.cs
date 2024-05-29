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
            return View(rooms);
        }

    }
}
