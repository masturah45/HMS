using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;
using MySql.Data.MySqlClient;

namespace HMS.Interfaces.Implementation
{
    public class BookingManager : IBookingManager
    {
        // public static List<Booking> listOfBookings = new List<Booking>();
        public string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";
        public void CreateBooking(DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,int roomtype, int duration)
        {
            Random random = new Random();
        //    int id = listOfBookings.Count + 1;

        //    if (checkInDate == DateTime.Now) ischecked = true;
          
        //    string customernumber = customer.CustomerNumber;

        //     if(roomtype == 1)
        //     {
        //         customer.Wallet -= 200000 * duration;
        //     }

        //     else if(roomtype == 2)
        //     {
        //         customer.Wallet -= 100000 * duration;
        //     }

        //     else if (roomtype == 3)
        //     {
        //         customer.Wallet -= 50000 * duration;
        //     }

        //     else if (roomtype == 4)
        //     {
        //         customer.Wallet -= 25000 * duration;
        //     }

        //     else if (roomtype == 5)
        //     {
        //         customer.Wallet -= 15000 * duration;
        //     }

        //     else
        //     {
        //         Console.WriteLine("Invalid Input");
        //     }

           Booking booking = new Booking (bookingDate, checkInDate, checkOutDate, ischecked, roomtype, duration);
        //    listOfBookings.Add(booking);
          var query = $"insert into booking (bookingDate, checkInDate, checkOutDate, duration)values ('{bookingDate}', '{checkInDate}', '{checkOutDate}', {duration})";
          
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        //    Console.WriteLine($"You have successfully booked a room \nDuration: {duration} \nAmount {customer.Wallet}");
        }

        public void DeleteBooking()
        {
            Console.Write("Enter bookingDate to delete: ");
            DateTime bookingDate = DateTime.Parse(Console.ReadLine().Trim());
            // foreach(var item in listOfBookings)
            // {
            //     if (item.BookingDate == bookingDate)
            //     {
            //         listOfBookings.Remove(item);
            //         break;
            //     }
            // }
        }

        public void GetAllBooking()
        {
            // foreach (var item in listOfBookings)
            // {
            //     Console.Write($"{item.BookingDate}\t{item.CheckInDate}\t{item.CheckOutDate}\t{item.isChecked}");
            // }
            Console.WriteLine();
        }

        public Booking GetAvailableRooms(int roomType, DateTime bookingDate, int duration)
        {
            // foreach (var item in listOfBookings)
            // {
            //     if (item.RoomType == roomType && item.BookingDate == bookingDate && item.Duration == duration )
            //     {
            //         Console.WriteLine($"You have successfully booked a room for yourself");
            //     }
            // }

            return null;
        }

        public Booking GetBooking( DateTime bookingDate)
        {
            // foreach(var booking in listOfBookings)
            // {
            //     if ( booking.BookingDate == bookingDate)
            //     {
            //         return booking;
            //     }
            // }
            return null;
        }

        // public Booking GetBooking(DateTime bookingDate)
        // {
        //     foreach (var booking in listOfBookings)
        //     {
        //         if (booking.BookingDate == bookingDate)
        //         {
        //             return booking;
        //         }
        //     }
        //     return null;
        // }

        public void UpdateBooking()
        {
            Console.Write("Enter the bookingdate to Update: ");
            DateTime bookingdate = DateTime.Parse(Console.ReadLine().Trim());
            Booking bookingdateToUpdate = GetBooking(bookingdate);
            if (bookingdateToUpdate != null)
            {
                Console.Write("Update checkInDate: ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.CheckInDate = checkInDate;

                Console.Write("Update checkOutDate: ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.CheckOutDate = checkOutDate;

                Console.Write("Update Duration:  ");
                int duration = int.Parse(Console.ReadLine().Trim());
                bookingdateToUpdate.Duration = duration;
                Console.WriteLine("booking updated successfully");
            }

            else
            {
                Console.WriteLine("booking not found");
            }
        }
    }

}