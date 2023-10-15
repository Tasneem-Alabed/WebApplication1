using WebApplication1.Modles.DTO;

namespace WebApplication1.Modles.Interfse
{
    public interface IRoom
    {
        Task<RoomDTO> Create(RoomDTO room);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> GetRoomId(int id);
        Task<RoomDTO> Update(int id, RoomDTO room);
        Task<RoomDTO> Delete(int id);

        Task<RoomAmenities> AddAmenityToRoom(int roomId, int amenityId);
        Task<RoomAmenities> RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
