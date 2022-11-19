using System;
namespace HMS.Model
{
    public class Booking
    {
       
        public DateTime BookingDate {get; set;}
        public DateTime CheckInDate {get; set;}
        public DateTime CheckOutDate {get; set;}
        public bool isChecked {get; set;}
        // public bool isAvailable {get; set;}
        public int RoomType {get; set;}
        public int Duration {get; set;}

        public Booking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,int roomType, int duration)
        {
            
            BookingDate = bookingDate;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            isChecked = ischecked;
            RoomType = roomType;
            Duration = duration;
        }
    }
}