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
            migrationBuilder.DropColumn(
                name: "BookingCount",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "images",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isBooked",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Name", "NationalID", "PhoneNumber", "isBooked" },
                values: new object[,]
                {
                    { 1, "Mohamed", "12345678912345", "01012345678", true },
                    { 2, "Ahmed", "12345678912367", "01012345690", true }
                });

            migrationBuilder.InsertData(
                table: "HotelBranches",
                columns: new[] { "BranchID", "BranchLocation", "BranchName" },
                values: new object[,]
                {
                    { 1, "Cairo", "HollaCairo" },
                    { 2, "Alex", "HollaAlex" },
                    { 3, "Dahab", "HollaDahab" }
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
                columns: new[] { "RoomID", "BookingID", "BranchID", "Description", "NumberOfAdults", "NumberOfChildren", "Price", "RoomNumber", "RoomType", "images" },
                values: new object[,]
                {
                    { 4, null, 1, "This Room Can Have Two Adults and One Child", 2, 1, 5000, 4, "Double", "[\"room4.jpeg\"]" },
                    { 5, null, 2, "This Room Can Have Two Adults and Two Children", 2, 2, 3000, 5, "Single", "[\"room5.jpeg\"]" },
                    { 6, null, 3, "This Room Can Have Three Adults and Two Children", 3, 2, 6000, 6, "Double", "[\"room6.jpeg\"]" },
                    { 1, 1, 1, "This Room Can Have One Person", 1, 0, 2000, 1, "Single", "[\"room1.jpeg\"]" },
                    { 2, 2, 2, "This Room Can Have Two People", 2, 0, 4000, 2, "Double", "[\"room2.jpeg\"]" },
                    { 3, 3, 3, "This Room Can Have One Person and One Child", 1, 1, 2800, 3, "Single", "[\"room3.jpeg\"]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BranchID",
                table: "Rooms",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HotelBranches_BranchID",
                table: "Rooms",
                column: "BranchID",
                principalTable: "HotelBranches",
                principalColumn: "BranchID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HotelBranches_BranchID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BranchID",
                table: "Rooms");

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

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "images",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BookingCount",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
