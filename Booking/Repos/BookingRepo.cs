using Booking.IRepos;
using Booking.Models;
using Booking.View_Model;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repos
{
    public class BookingRepo : IBookingRepo
    {
        dbContext db;
        public BookingRepo(dbContext _db)
        {
            db = _db;
        }

        public void create(BookingVM data)
        {
            //1. if this user exist in db and he booked before
            var customer = db.Customers.FirstOrDefault(u => u.NationalID == data.NationalID);
            if(customer == null)
            {
                // Create a new customer if not found
                customer = new Customer
                {
                    Name = data.CustomerName,
                    NationalID = data.NationalID,
                    PhoneNumber = data.PhoneNumber,
                    isBooked = true
                };
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            else
            {
                data.DiscountApplied = true; // Apply discount for returning customers
            }


            var branch = db.HotelBranches.FirstOrDefault(b => b.BranchName == data.BranchName);
            // Create the booking model
            var booking = new BookingModel
            {
                CustomerID = customer.CustomerID,
                BranchID = branch.BranchID,
                CheckInDate = data.CheckInDate,
                CheckOutDate = data.CheckOutDate,
                TotalRooms = data.TotalRooms,
                DiscountApplied = data.DiscountApplied,
                RoomNumbers = data.RoomNumber
            };
            db.Bookings.Add(booking);
            db.SaveChanges();

            // Retrieve the rooms and update with booking ID
            var rooms = db.Rooms
                                .Where(r => data.RoomNumber.Contains(r.RoomNumber))
                                .ToList();

            foreach (var room in rooms)
            {
                room.BookingID = booking.BookingID;
            }

            db.SaveChanges();
        }
    }
}
 