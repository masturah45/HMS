using System;
namespace Hotel_Management_System.Model
{
    public class Booking
    {
        public int Id {get; set;}
        public DateTime BookingDate {get; set;}
        public DateTime CheckInDate {get; set;}
        public DateTime CheckOutDate {get; set;}
        public bool isChecked {get; set;}
        public bool isAvailable {get; set;}
        public int RoomType {get; set;}
        public string Duration {get; set;}

        public Booking (int id, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked, bool isavailable, int roomType, string duration)
        {
            Id = id;
            BookingDate = bookingDate;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            isChecked = ischecked;
            isAvailable = isavailable;
            RoomType = roomType;
            Duration = duration;

        }
    }
}