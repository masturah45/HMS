using System;
using HMS.Model;

namespace HMS.Interfaces
{
    public interface IBookingManager
    {
        public Booking GetBooking ( DateTime bookingDate);
        public void UpdateBooking ();
        public void DeleteBooking ();
        // public Booking GetBooking (DateTime bookingDate);
        public void GetAllBooking ();
        public void CreateBooking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,int roomtype, int duration);
        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, int duration );
    }
}
