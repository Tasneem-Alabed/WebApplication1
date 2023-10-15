using WebApplication1.Modles.DTO;

namespace WebApplication1.Modles.Interfse
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel hotel);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> GetHotelId(int id);
        Task<Hotel> Update(int id, Hotel hotel);
        Task Delete(int id);
    }
}
