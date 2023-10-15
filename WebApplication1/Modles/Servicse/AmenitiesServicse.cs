using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.Interfse;
using WebApplication1.Modles.Interfse;
namespace WebApplication1.Modles.Servicse
{
    public class AmenitiesServicse : IAmenities
    {
        private readonly HotelDbContest _context;

        public AmenitiesServicse(HotelDbContest context)
        {
            _context = context;
        }
        public async Task<Amenities> Create(Amenities aminity)
        {
            _context.Amenities.Add(aminity);
            await _context.SaveChangesAsync();
            return aminity;
        }

        public async Task<Amenities> Delete(int id)
        {
            var aminty = await GetAmenitieId(id);
            _context.Entry(aminty).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return aminty;
        }

        public async Task<Amenities> GetAmenitieId(int id)
        {
            var amiety = await _context.Amenities.FindAsync(id);
            return amiety;
        }

        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> Update(int id, Amenities updateAmenites)
        {
            var amenty = await GetAmenitieId(id);
            amenty.Name = updateAmenites.Name;
            amenty.RoomAmeneties = updateAmenites.RoomAmeneties;
            _context.Entry(amenty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenty;
        }
    }
}

