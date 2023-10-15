using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.Interfse;
namespace WebApplication1.Modles.Servicse
{
    public class HotelServices : IHotel
    {
        private readonly HotelDbContest _context;

        public HotelServices(HotelDbContest context)
        {
            _context = context;
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> Delete(int id)
        {
            Hotel hotel = await GetHotelId(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> GetHotelId(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;

        }

        public async Task<List<Hotel>> GetHotels()
        {

            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> Update(int id, Hotel hotel)
        {

            Hotel Temphotel = await GetHotelId(id);
            Temphotel.Name = hotel.Name;
            Temphotel.StreetAddres = hotel.StreetAddres;
            Temphotel.City = hotel.City;
            Temphotel.Srate = hotel.Srate;
            Temphotel.Country = hotel.Country;
            Temphotel.Phone = hotel.Phone;
            Temphotel.HotelRooms = hotel.HotelRooms;






            _context.Entry(Temphotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Temphotel;
        }

    }
}
