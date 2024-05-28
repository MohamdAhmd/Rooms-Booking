using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BookingCount", "Name", "NationalID", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, "Mohamed", "12345678912345", "01012345678" },
                    { 2, 1, "Ahmed", "12345678912367", "01012345690" }
                });

            migrationBuilder.InsertData(
                table: "HotelBranches",
                columns: new[] { "BranchID", "BranchLocation", "BranchName" },
                values: new object[,]
                {
                    { 1, "Cairo", "Holla" },
                    { 2, "Alex", "Holla" },
                    { 3, "Dahab", "Holla" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "BookingID", "Description", "NumberOfAdults", "NumberOfChildren", "Price", "RoomNumber", "RoomType", "images" },
                values: new object[,]
                {
                    { 4, null, "This Room Can Have Two Adults and One Child", 2, 1, 5000, 4, "Double", "[]" },
                    { 5, null, "This Room Can Have Two Adults and Two Children", 2, 2, 3000, 5, "Single", "[]" },
                    { 6, null, "This Room Can Have Three Adults and Two Children", 3, 2, 6000, 6, "Double", "[]" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingID", "BranchID", "CheckInDate", "CheckOutDate", "CustomerID", "DiscountApplied", "RoomNumbers", "TotalRooms" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "[1]", 1 },
                    { 2, 2, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "[2]", 1 },
                    { 3, 3, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, "[3]", 1 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomID", "BookingID", "Description", "NumberOfAdults", "NumberOfChildren", "Price", "RoomNumber", "RoomType", "images" },
                values: new object[,]
                {
                    { 1, 1, "This Room Can Have One Person", 1, 0, 2000, 1, "Single", "[]" },
                    { 2, 2, "This Room Can Have Two People", 2, 0, 4000, 2, "Double", "[]" },
                    { 3, 3, "This Room Can Have One Person and One Child", 1, 1, 2800, 3, "Single", "[]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelBranches",
                keyColumn: "BranchID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HotelBranches",
                keyColumn: "BranchID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HotelBranches",
                keyColumn: "BranchID",
                keyValue: 3);
        }
    }
}
