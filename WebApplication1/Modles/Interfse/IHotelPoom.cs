using WebApplication1.Modles.DTO;

namespace WebApplication1.Modles.Interfse
{
    public interface IHotelPoom
    {
        Task<Hotel> Create(Hotel HotelRoom);
        Task<List<Hotel>> GetHotelRooms();
        Task<Hotel> GetHotelRoomId(int idHotel, int idRoom);
        Task<Hotel> Update(int idHotel, int idRoom, Hotel HotelRoom);
        Task<Hotel> Delete(int idHotel, int idRoom);
    }
}
