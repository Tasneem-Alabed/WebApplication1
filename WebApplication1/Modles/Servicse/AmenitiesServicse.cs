using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.DTO;
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
        public async Task<AminityDTO> Create(AminityDTO aminity)
        {
            var newAmenity = new Amenities()
            {
                Name = aminity.Name,
            };
            _context.Amenities.Add(newAmenity);

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

        public async Task<List<AminityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities
                .Select(amenity => new AminityDTO
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                }).ToListAsync();

            return amenities;
        }

      
        public async Task<Amenities> Update(int id, Amenities amenities)
        {
            var amenty = await GetAmenitieId(id);
            amenty.Name = amenities.Name;
            amenty.RoomAmeneties = amenities.RoomAmeneties;
            _context.Entry(amenty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenty;
        }
    }
}

