namespace WebApplication1.Modles
{
    public class Room
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Layout { get; set; }

        public int Rooms { get; set; }

        public List<RoomAmenities> RoomAmeneties { get; set; }

    }
}
