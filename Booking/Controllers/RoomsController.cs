using Booking.IRepos;
using Booking.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class RoomsController : Controller
    {
        IRoomRepo RoomRepo;
        public RoomsController(IRoomRepo _roomRepo)
        {
            RoomRepo = _roomRepo;
        }

        public IActionResult Details(int id)
        {
            var room = RoomRepo.GetById(id);
            return View(room);
        }
    }
}
