using System;
using System.Collections.Generic;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces.Implementation
{
    public class BookingManager : IBookingManager
    {
        public static List<Booking> listOfBookings = new List<Booking>();
        public void CreateBooking( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, string roomId, bool isavailable, int roomtype, string duration)
        {
            Random random = new Random();
           int id = listOfBookings.Count + 1;
           bool ischecked = false;
           if (checkInDate == DateTime.Now)
           {
               ischecked = true;
           }
           string customernumber = "MTC/CTM" + random.Next(100, 999).ToString();
            Booking booking = new Booking ( id, bookingDate, checkInDate, checkOutDate, ischecked, isavailable, roomtype, duration);
            listOfBookings.Add(booking);
            Console.WriteLine("You have successfully booked a room");
        }

        public void DeleteBooking(DateTime checkInDate)
        {
            Booking book = GetBooking(checkInDate);
            if (book != null)
            {
                listOfBookings.Remove(book);
            }
            else
            {
                Console.WriteLine("Booking not found");
            }
        }

        public void GetAllBooking()
        {
            foreach (var item in listOfBookings)
            {
                Console.Write($"{item.Id}\t{item.BookingDate}\t{item.CheckInDate}\t{item.CheckOutDate}\t{item.isChecked}");
            }
            Console.WriteLine();
        }

        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, string duration)
        {
            foreach (var item in listOfBookings)
            {
                if (item.RoomType == roomType && item.BookingDate == bookingDate && item.Duration == duration )
                {
                    Console.WriteLine($"You have successfully booked a room for yourself");
                }
            }

            return null;
        }

        public Booking GetBooking(int id, DateTime bookingDate)
        {
            foreach(var booking in listOfBookings)
            {
                if (booking.Id == id && booking.BookingDate == bookingDate)
                {
                    return booking;
                }
            }
            return null;
        }

        public Booking GetBooking(DateTime bookingDate)
        {
            foreach (var booking in listOfBookings)
            {
                if (booking.BookingDate == bookingDate)
                {
                    return booking;
                }
            }
            return null;
        }

        public void UpdateBooking(DateTime bookingDate,DateTime checkInDate, DateTime checkOutDate)
        {
            Booking booking = GetBooking(bookingDate);
            if (booking == null)
            {
                Console.WriteLine("Booking not found");
            }
            else
            {
                booking.CheckInDate = checkInDate;
                booking.CheckOutDate = checkOutDate;
            }
            listOfBookings[booking.Id - 1] = booking;
        }
    }

}