namespace WebApplication1.Modles
{
    public class RoomAmenities
    {
        public int Id { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
        public Amenities Ameneties { get; set; }
    }
}
