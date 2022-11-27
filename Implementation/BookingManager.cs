using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;
using MySql.Data.MySqlClient;

namespace HMS.Interfaces.Implementation
{
    public class BookingManager : IBookingManager
    {
        public string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";
        public void CreateBooking ( DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, bool ischecked,string roomtype, int duration)
        {
            Random random = new Random();
            
           Booking booking = new Booking (bookingDate, checkInDate, checkOutDate, ischecked, roomtype, duration);
          var query = $"insert into booking (bookingNumber,bookingDate, checkInDate, checkOutDate, duration, roomtype, ischecked)values ('{Booking.GenerateBookingNumber()}', '{bookingDate}', '{checkInDate}', '{checkOutDate}', {duration}, '{roomtype}', {ischecked})";
          
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
            Console.WriteLine($"You have successfully booked a room \nDuration {duration} and your bookingNumber is {Booking.GenerateBookingNumber()}");
        }

        public void DeleteBooking(string bookingNumber)
        {
            var booking = GetBooking(bookingNumber);
            if (booking != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{booking.CheckInDate} {booking.CheckOutDate} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From booking WHERE BookingNumber = '{bookingNumber}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            System.Console.WriteLine(deleteSuccessMsg);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("booking not found.");
            }
        }

        public void GetAllBooking()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From bookings", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["BookingDate"]}\t{reader["CheckInDate"]}\t{reader["CheckOutDate"].ToString()}\t{reader["isChecked"].ToString()}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public Booking GetAvailableRooms(string roomType, DateTime bookingDate, int duration)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From booking", connection))
                    {
                        var reader = command.ExecuteReader();
                     while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Roomtype"]}\t{reader["Bookingdate"]}\t{reader["duration"]}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return null;
        }

        public Booking   GetBooking(string bookingNumber)
        {
            Booking booking = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From booking WHERE BookingNumber = '{bookingNumber}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            booking = new Booking(DateTime.Parse(reader["bookingDate"].ToString()), DateTime.Parse(reader["checkInDate"].ToString()), DateTime.Parse(reader["checkOutDate"].ToString()), bool.Parse(reader["isChecked"].ToString()), reader["roomtype"].ToString(),Convert.ToInt32(reader["duration"]));
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return booking;
        }

        public void UpdateBooking(DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate, int duration)
        {
            try
            {
                using(var connection = new MySqlConnection(connectionString))
                {
                    var msg = $"{bookingDate} Updated Sucessfully";
                    connection.Open();
                    var queryUpdateA = $"Update bookings SET checkInDate = '{checkInDate}', checkOutDte = '{checkOutDate}', duration = '{duration}' where bookingDate = '{bookingDate}'";
                    using (var command = new MySqlCommand(queryUpdateA, connection))
                    {
                        var yes = command.ExecuteNonQuery();
                        System.Console.WriteLine(msg);
                    }
                }
            }
            catch (System.Exception ex)
            {
                
                System.Console.WriteLine(ex.Message);
            }
        }
    }

}