using System;
namespace HMS.Model
{
    public class Booking
    {
        public string BookingNumber {get; set;}
        public DateTime BookingDate {get; set;}
        public DateTime CheckInDate {get; set;}
        public DateTime CheckOutDate {get; set;}
        public bool isChecked {get; set;}
        // public bool isAvailable {get; set;}
        public string RoomType {get; set;}
        public int Duration {get; set;}

        public Booking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,string roomType, int duration)
        {
            BookingNumber = GenerateBookingNumber();            
            BookingDate = bookingDate;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            isChecked = ischecked;
            RoomType = roomType;
            Duration = duration;
        }
        public static string GenerateBookingNumber()
        {
            Random rand = new Random();
            return "FIVE/STARS" + rand.Next(100, 999).ToString();
        }
    }
}