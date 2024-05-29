using Booking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Booking.SeedData
{
    public static class Data
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, Name = "Mohamed", NationalID = "12345678912345", PhoneNumber = "01012345678", BookingCount = 0 },
                new Customer { CustomerID = 2, Name = "Ahmed", NationalID = "12345678912367", PhoneNumber = "01012345690", BookingCount = 1 }
            );

            modelBuilder.Entity<HotelBranch>().HasData(
                new HotelBranch { BranchID = 1, BranchName = "HollaCairo", BranchLocation = "Cairo" },
                new HotelBranch { BranchID = 2, BranchName = "HollaAlex", BranchLocation = "Alex" },
                new HotelBranch { BranchID = 3, BranchName = "HollaDahab", BranchLocation = "Dahab" }
            );

            modelBuilder.Entity<BookingModel>().HasData(
                new BookingModel { BookingID = 1, CustomerID = 1, BranchID = 1, CheckInDate = new DateTime(2020, 1, 7), CheckOutDate = new DateTime(2020, 1, 11), TotalRooms = 1, DiscountApplied = false, RoomNumbers = new List<int> { 1 } },
                new BookingModel { BookingID = 2, CustomerID = 2, BranchID = 2, CheckInDate = new DateTime(2021, 1, 12), CheckOutDate = new DateTime(2021, 1, 14), TotalRooms = 1, DiscountApplied = true, RoomNumbers = new List<int> { 2 } },
                new BookingModel { BookingID = 3, CustomerID = 1, BranchID = 3, CheckInDate = new DateTime(2022, 1, 16), CheckOutDate = new DateTime(2022, 1, 20), TotalRooms = 1, DiscountApplied = false, RoomNumbers = new List<int> { 3 } }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { RoomID = 1, BranchID = 1, RoomNumber = 1, RoomType = "Single", Price = 2000, NumberOfChildren = 0, NumberOfAdults = 1, Description = "This Room Can Have One Person", BookingID = 1, images = ["room1.jpeg"] },
                new Room { RoomID = 2, BranchID = 2, RoomNumber = 2, RoomType = "Double", Price = 4000, NumberOfChildren = 0, NumberOfAdults = 2, Description = "This Room Can Have Two People", BookingID = 2, images = ["room2.jpeg"] },
                new Room { RoomID = 3, BranchID = 3, RoomNumber = 3, RoomType = "Single", Price = 2800, NumberOfChildren = 1, NumberOfAdults = 1, Description = "This Room Can Have One Person and One Child", BookingID = 3, images = ["room3.jpeg"] },
                new Room { RoomID = 4, BranchID = 1, RoomNumber = 4, RoomType = "Double", Price = 5000, NumberOfChildren = 1, NumberOfAdults = 2, Description = "This Room Can Have Two Adults and One Child", BookingID = null, images = ["room4.jpeg"] },
                new Room { RoomID = 5, BranchID = 2, RoomNumber = 5, RoomType = "Single", Price = 3000, NumberOfChildren = 2, NumberOfAdults = 2, Description = "This Room Can Have Two Adults and Two Children", BookingID = null, images = ["room5.jpeg"] },
                new Room { RoomID = 6, BranchID = 3, RoomNumber = 6, RoomType = "Double", Price = 6000, NumberOfChildren = 2, NumberOfAdults = 3, Description = "This Room Can Have Three Adults and Two Children", BookingID = null, images = ["room6.jpeg"] }
            );

        }
    }
}
