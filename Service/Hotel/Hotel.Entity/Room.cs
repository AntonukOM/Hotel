namespace Hotel.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public bool Approved { get; set; }
    }
}
