using System;

namespace Hotel.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }
        public DateTime ReservationBegin { get; set; }
        public DateTime ReservationEnd { get; set; }
        public bool Approved { get; set; }
    }
}
