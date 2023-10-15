using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.Interfse;
namespace WebApplication1.Modles.Servicse

{
    public class RoomServicse : IRoom
    {
        private readonly HotelDbContest _context;

        public RoomServicse(HotelDbContest context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();
            return room;


        }

        public async Task<Room> Delete(int id)
        {
            Room room = await GetRoomId(id);
            _context.Entry(room).State = EntityState.Deleted;
            return room;

        }

        public async Task<Room> GetRoomId(int id)
        {
            Room room = await _context.Room.FindAsync(id);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Room
                .Include(r => r.RoomAmeneties)
                    .ThenInclude(ra => ra.Ameneties)
                .Include(hotelRooms => hotelRooms.Rooms)
                
                .ToListAsync();


            var result = rooms.Select(r => new Room
            {
                ID = r.ID,
                Name = r.Name,
                Layout = r.Layout,
                RoomAmeneties = r.RoomAmeneties.Select(ra => new RoomAmenities
                {
                    RoomId = ra.RoomId,
                    Id = ra.Id,
                    Ameneties = new Amenities
                    {
                        Id = ra.Ameneties.Id,
                        Name = ra.Ameneties.Name,
                    },
                    Room = null

                }).ToList(),
               
                    


            }).ToList();

            return result;
        }

        public async Task<Room> Update(int id, Room room)
        {
            var Temproom = await GetRoomId(id);
            Temproom.Name = room.Name;
            Temproom.Layout = room.Layout;
            Temproom.Rooms = room.Rooms;
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<RoomAmenities> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var roomameneties = await _context.RoomAmenities.Where(x => x.RoomId == roomId && x.Id == amenityId).FirstOrDefaultAsync();
            _context.Entry(roomameneties).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return roomameneties;
        }

        public async Task<RoomAmenities> AddAmenityToRoom(int roomId, int amenityId)
        {
            var roomameneties = await _context.RoomAmenities.Where(x => x.RoomId == roomId && x.Id == amenityId).FirstOrDefaultAsync();
            _context.Entry(roomameneties).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return roomameneties;
        }
    }
}

