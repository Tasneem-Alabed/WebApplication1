using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.DTO;
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

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotelId(id);

            _context.Entry<HotelDTO>(hotel).State = EntityState.Deleted;


            await _context.SaveChangesAsync();
            
        }

        public async Task<HotelDTO> GetHotelId(int id)
        {
            HotelDTO? HotelById = await _context.Hotels
                 .Select(h => new HotelDTO
                 {
                     ID = h.Id,
                     Name = h.Name,
                     City = h.City,
                     State = h.Srate,
                     StreetAddress = h.StreetAddres,
                     Phone = h.Phone,
                     Rooms = h.HotelRooms.Select(hr => new HotelRoomDTO
                     {
                         HotelID = hr.Id,
                         RoomNumber = hr.RoomNumber,
                         Rate = hr.Rate,
                         IsPetFriendly = hr.PitFriendly,
                         RoomID = hr.RoomId,
                         Room = new RoomDTO
                         {
                             ID = hr.Room.ID,
                             Name = hr.Room.Name,
                             Layout = hr.Room.Layout,
                             Amenities = hr.Room.RoomAmeneties.Select(am => new AminityDTO()
                             {
                                 Id = am.Ameneties.Id,
                                 Name = am.Ameneties.Name
                             }).ToList()

                         }

                     }).ToList()
                 }).FirstOrDefaultAsync(x => x.ID == id);

            return HotelById;

        }

        public async Task<List<HotelDTO>> GetHotels()
        {

            return await _context.Hotels
                .Select(h => new HotelDTO
                {
                    ID = h.Id,
                    Name = h.Name,
                    City = h.City,
                    State = h.Srate,
                    StreetAddress = h.StreetAddres,
                    Phone = h.Phone,
                    Rooms = h.HotelRooms.Select(hr => new HotelRoomDTO
                    {
                        HotelID = hr.Id,
                        RoomNumber = hr.RoomNumber,
                        Rate = hr.Rate,
                        IsPetFriendly = hr.PitFriendly,
                        RoomID = hr.RoomId,
                        Room = new RoomDTO
                        {
                            ID = hr.Room.ID,
                            Name = hr.Room.Name,
                            Layout = hr.Room.Layout,
                            Amenities = hr.Room.RoomAmeneties.Select(am => new AminityDTO()
                            {
                                Id = am.Ameneties.Id,
                                Name = am.Ameneties.Name
                            }).ToList()

                        }

                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<Hotel> Update(int id, Hotel hotel)
        {

            hotel.Id = id;
           _context.Entry<Hotel>(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return hotel;
        }

    }
}
