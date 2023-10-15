namespace WebApplication1.Modles
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddres { get; set; }

        public string City { get; set; }
        public string Srate { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
    }
}
