using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    [Serializable]
    public enum roomStatus { Free, Booked, Busy }
    [Serializable]
    class Hotel
    {
        public string HotelName { get; set; }
        public int AmountRooms { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public Room[] Rooms { get; set; }
    }
    [Serializable]
    class Room
    {
        public int Number { get; set; }
        public roomStatus Status { get; set; }
        public DateTime BookDateFrom { get; set; }
        public DateTime BookDateTo { get; set; }
        public Boolean BookAprooved { get; set; }
    }
}
