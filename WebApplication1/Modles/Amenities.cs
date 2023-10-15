namespace WebApplication1.Modles
{
    public class Amenities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RoomAmenities> RoomAmeneties { get; set; }
    }
}
