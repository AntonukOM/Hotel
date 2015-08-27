using System.Runtime.Serialization;

namespace Hotel.Service.DTOs
{
    [DataContract]
    public class RoomDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int HotelId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool Approved { get; set; }
    }
}