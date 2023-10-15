using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles;
using WebApplication1.Modles.Interfse;
using WebApplication1.Modles.Servicse;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<HotelDbContest>(options => options.UseSqlServer(connString));
            builder.Services.AddControllers();
            builder.Services.AddTransient<IHotel, HotelServices>();
            builder.Services.AddTransient<IRoom, RoomServicse>();
            builder.Services.AddTransient<IAmenities, AmenitiesServicse>();
            builder.Services.AddTransient<IHotelPoom, HotelRoomRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello !");

            app.Run();
        }
    }
}