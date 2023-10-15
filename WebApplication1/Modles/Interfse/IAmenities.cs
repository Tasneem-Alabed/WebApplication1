using WebApplication1.Modles.DTO;

namespace WebApplication1.Modles.Interfse
{
    public interface IAmenities
    {
        Task<AminityDTO> Create(AminityDTO aminity);
        Task<List<AminityDTO>> GetAmenities();
              Task<Amenities> Update(int id, Amenities amenities);
        Task<Amenities> Delete(int id);
    }
}
