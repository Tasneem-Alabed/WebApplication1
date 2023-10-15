using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Modles;

namespace WebApplication1.Data
{
    public class HotelDbContest : DbContext
    {
        public HotelDbContest(DbContextOptions options) : base(options)
        {

            

    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    Name = "Five",
                    StreetAddres = "Moon",
                    City = "Amman",
                    Srate = "do",
                    Country = "oo",
                    Phone = "000000000",
                   
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Five",
                    StreetAddres = "Moon",
                    City = "Amman",
                    Srate = "do",
                    Country = "oo",
                    Phone = "000000000",
                   
                }, new Hotel()
                {
                    Id = 3,
                    Name = "Five",
                    StreetAddres = "Moon",
                    City = "Amman",
                    Srate = "do",
                    Country = "oo",
                    Phone = "000000000",
                   
                }


                );

            modelBuilder.Entity<Room>().HasData(
                new Room() { ID =1 , Name ="p" , Layout=9 , Rooms=8 }, 
                new Room() { ID = 2, Name = "p", Layout = 9, Rooms = 8 },
                new Room() { ID = 3, Name = "p", Layout = 9, Rooms = 8 }
                );
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities() {Id =1 , Name = "do"  }, 
                new Amenities() { Id = 2, Name = "do" }, 
                new Amenities() { Id = 3, Name = "do"}
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
               roomamanites => new { roomamanites.RoomId, roomamanites.Id }
               );
            modelBuilder.Entity<HotelRoom>().HasKey(
               roomamanites => new { roomamanites.Id, roomamanites.RoomNumber }
               );

        }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<HotelRoom> HotelRoom { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
    }

