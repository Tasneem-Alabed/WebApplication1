namespace WebApplication1.Modles.Interfse
{
    public interface IAmenities
    {
        Task<Amenities> Create(Amenities aminity);
        Task<List<Amenities>> GetAmenities();
        Task<Amenities> GetAmenitieId(int id);
        Task<Amenities> Update(int id, Amenities amenities);
        Task<Amenities> Delete(int id);
    }
}
