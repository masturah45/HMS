using System;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces
{
    public interface IBookingManager
    {
        public Booking GetBooking (int id, DateTime bookingDate);
        public void UpdateBooking (DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate);
        public void DeleteBooking (DateTime checkInDate);
        public Booking GetBooking (DateTime bookingDate);
        public void GetAllBooking ();
        public void CreateBooking (DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, string roomId, bool isavailable, int roomtype, string duration);
        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, string duration );
    }
}