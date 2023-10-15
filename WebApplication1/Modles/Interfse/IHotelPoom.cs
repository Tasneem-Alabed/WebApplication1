namespace WebApplication1.Modles.Interfse
{
    public interface IHotelPoom
    {
        Task<HotelRoom> Create(HotelRoom HotelRoom);
        Task<List<HotelRoom>> GetHotelRooms();
        Task<HotelRoom> GetHotelRoomId(int idHotel, int idRoom);
        Task<HotelRoom> Update(int idHotel, int idRoom, HotelRoom HotelRoom);
        Task<HotelRoom> Delete(int idHotel, int idRoom);
    }
}
