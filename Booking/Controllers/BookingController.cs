using Booking.IRepos;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class BookingController : Controller
    {
        IBookingRepo bookingRepo;
        public BookingController(IBookingRepo _bookingRepo)
        {
            bookingRepo = _bookingRepo;
        }
        public IActionResult Index([FromForm] BookingModel data)
        {
            bookingRepo.create(data);
            return View();
        }
    }
}
