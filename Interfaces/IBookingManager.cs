using System;
using HMS.Model;

namespace HMS.Interfaces
{
    public interface IBookingManager
    {
        public void UpdateBooking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, int duration);
        public void DeleteBooking (string bookingNumber);
        public Booking GetBooking (string bookingNumber);
        public void GetAllBooking ();
        public void CreateBooking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,string roomtype, int duration);
        public Booking GetAvailableRooms(string roomType, DateTime bookingDate, int duration );
    }
}
