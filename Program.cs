using System;
using HMS.Interfaces.Implementation;
using HMS.Menu;
using MySql.Data.MySqlClient;

namespace HMS
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.WelcomePage();
            // var rm = new BookingManager();
            // rm.CreateBooking( DateTime.Parse("2007-10-11"), DateTime.Parse("2007-10-12"), DateTime.Parse("2007-10-14"), true, 4, 3 );
           // rm.CreateBooking( DateTime.Parse("2007-09-7"), DateTime.Parse("2007-09-10"), DateTime.Parse("2007-09-15"), true, 3, 5);

            // string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";

            // var query = "CREATE TABLE Booking (ID int auto_increment, bookingDate Date, checkInDate Date, checkOutDate Date, Duration int,  primary key (id))";
            // try
            // {
            //     using (var connection = new MySqlConnection(connectionString))
            //     {
            //         connection.Open();
            //         using (MySqlCommand command = new MySqlCommand(query, connection))
            //         {
            //             command.ExecuteNonQuery();
            //             System.Console.WriteLine("Succesful");
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            // }


        }
    }

}
