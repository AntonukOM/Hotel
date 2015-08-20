using System.Runtime.Serialization;

namespace Hotel.Service.DTOs
{
    [DataContract]
    public class HotelDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}