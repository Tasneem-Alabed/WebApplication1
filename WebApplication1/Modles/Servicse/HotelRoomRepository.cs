using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.Interfse;

namespace WebApplication1.Modles.Servicse
{
    public class HotelRoomRepository : IHotelPoom
    {
        private readonly HotelDbContest _context;

        public HotelRoomRepository(HotelDbContest context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(HotelRoom HotelRoom)
        {
            HotelRoom.Hotel = await _context.Hotels.Where(x => x.Id == HotelRoom.Id).FirstOrDefaultAsync();
            HotelRoom.Room = await _context.Room.Where(x => x.ID == HotelRoom.RoomId).FirstOrDefaultAsync();

            _context.HotelRoom.Add(HotelRoom);
            await _context.SaveChangesAsync();
            return HotelRoom;
        }

        public async Task<HotelRoom> Delete(int idHotel, int idRoom)
        {
            var HotelRoom = await GetHotelRoomId(idHotel, idRoom);
            _context.Entry(HotelRoom).State = EntityState.Deleted;
            return HotelRoom;
        }

        public async Task<HotelRoom> GetHotelRoomId(int idHotel, int idRoom)
        {
            var HotelRoom = await _context.HotelRoom.Where(x => x.Id == idHotel && x.RoomId == idRoom).FirstOrDefaultAsync();
            return HotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRoom.ToListAsync();

        }

        public async Task<HotelRoom> Update(int idHotel, int idRoom, HotelRoom HotelRoom)
        {
            var Temproom = await GetHotelRoomId(idHotel, idRoom);
            Temproom.RoomNumber = HotelRoom.RoomNumber;
            Temproom.Rate = HotelRoom.Rate;
            Temproom.PitFriendly = HotelRoom.PitFriendly;
            _context.Entry(Temproom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Temproom;

        }
    }
}
