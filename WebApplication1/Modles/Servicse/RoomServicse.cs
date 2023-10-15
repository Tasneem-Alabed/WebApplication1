using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Modles.DTO;
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
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            Room newRoom = new Room()
            {
                ID = room.ID,
                Name = room.Name,
                Layout = room.Layout
            };
            _context.Entry(newRoom).State = EntityState.Added;

            await _context.SaveChangesAsync();
            room.ID = newRoom.ID;

           //

            //await AddAmenityToRoom(newRoom.ID, getAmenity.Id);

            RoomDTO newRoomWithAmenity = await GetRoomId(room.ID);

            return newRoomWithAmenity;

        }

        public async Task<RoomDTO> Delete(int id)
        {
            RoomDTO room = await GetRoomId(id);

            _context.Entry<RoomDTO>(room).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<RoomDTO> GetRoomId(int id)
        {
            RoomDTO? room = await _context.Room
              .Select(r => new RoomDTO
              {
                  ID = r.ID,
                  Name = r.Name,
                  Layout = r.Layout,
                  Amenities = r.RoomAmeneties
                  .Select(am => new AminityDTO
                  {
                      Id = am.Ameneties.Id,
                      Name = am.Ameneties.Name

                  }).ToList()
              }).FirstOrDefaultAsync(x => x.ID == id);

            return room;
        }

        public async Task<List<RoomDTO>> GetRooms()
        {

            return await _context.Room
                  .Select(r => new RoomDTO
                  {
                      ID = r.ID,
                      Name = r.Name,
                      Layout = r.Layout,
                      Amenities = r.RoomAmeneties
                  .Select(am => new AminityDTO
                  {
                      Id = am.Ameneties.Id,
                      Name = am.Ameneties.Name

                  }).ToList()
                  }).ToListAsync();
        }

        public async Task<RoomDTO> Update(int id, RoomDTO room)
        {
            var Temproom = await GetRoomId(id);
            Temproom.Name = room.Name;
            Temproom.Layout = room.Layout;
           
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task<RoomAmenities> RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removedRoomsAmenity = await _context.RoomAmenities.FirstOrDefaultAsync(roomAmenities => roomAmenities.RoomId == roomId && roomAmenities.Id == amenityId);

            _context.Entry<RoomAmenities>(removedRoomsAmenity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return removedRoomsAmenity;

        }

        public async Task<RoomAmenities> AddAmenityToRoom(int roomId, int amenityId)
        {
          
            var addAmenityToRoom = new RoomAmenities { RoomId = roomId, Id = amenityId };
            _context.RoomAmenities.Add(addAmenityToRoom);
            await _context.SaveChangesAsync();
            return addAmenityToRoom;
        }
    }
}

