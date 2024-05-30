using Booking.Models;
using Booking.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Booking.Models
{
    public class dbContext : DbContext
    {
        public dbContext() { }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerID);
                entity.Property(c => c.isBooked)
                        .HasDefaultValue(false);
            });

            modelBuilder.Entity<HotelBranch>(entity =>
            {
                entity.HasKey(e => e.BranchID);
                entity.Property(e => e.BranchID)
                      .ValueGeneratedOnAdd(); 
            });

            modelBuilder.Entity<BookingModel>(entity =>
            {
                entity.HasKey(b => b.BookingID);
            });

            modelBuilder.Entity<Room>(entity => {
                entity.HasKey(r => r.RoomID);
                entity.Property(p => p.BookingID)
                    .HasDefaultValueSql(null);
            });

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerID);

            modelBuilder.Entity<HotelBranch>()
                .HasMany(h => h.Bookings)
                .WithOne(b => b.HotelBranch)
                .HasForeignKey(b => b.BranchID);

            modelBuilder.Entity<HotelBranch>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.HotelBranch)
                .HasForeignKey(r => r.BranchID);

            modelBuilder.Entity<BookingModel>()
                .HasMany(b => b.Rooms)
                .WithOne(r => r.Booking)
                .HasForeignKey(r => r.BookingID)
                .IsRequired(false); // Because BookingID can be null

            modelBuilder.SeedData();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelBranch> HotelBranches { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
