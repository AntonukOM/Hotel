using Hotel.Entity;
using System.Collections.Generic;

namespace Hotel.Repository
{
    public interface IHotelRepository
    {
        List<Hotels> GetHotels();
        int HotelId(string hotelName);
    }
}
