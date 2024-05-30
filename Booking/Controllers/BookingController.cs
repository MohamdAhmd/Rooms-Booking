using Booking.IRepos;
using Booking.Models;
using Booking.View_Model;
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

        public IActionResult Index()
        {
            var res = bookingRepo.index();
            return View("create",res);
        }

        public IActionResult Create([FromForm] BookingVM data)
        {
            bookingRepo.create(data);
            return Json(new { message = "Booking successfully created!" });
        }
    }
}
