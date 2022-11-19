using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;
using MySql.Data.MySqlClient;

namespace HMS.Interfaces.Implementation
{
    public class RoomManager : IRoomManager
    {
        // public static List<Room> listOfRooms = new List<Room>();
        public string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";
        public void CreateRoom(string type, double price)
        {    
            Random rand = new Random();
            // int id = listOfRooms.Count + 1;
            string roomNumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Room room = new Room(type, price,roomNumber);
            // listOfRooms.Add(room);
             var query = $"insert into rooms (type, price)values ('{type}', {price})";
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
            Console.WriteLine($"thank you, {room.Type} created succesfully and the room number is {room.RoomNumber}");
        }

         public void DeleteRoom(string type)
        {
           var room = GetRoom(type);
            if (room != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{room.Price} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From rooms WHERE Type = '{type}'", connection))
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
                Console.WriteLine("Room not found.");
            }
        }

        public void GetAllRooms()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From rooms", connection))
                    {
                        var reader = command.ExecuteReader();
                      while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Type"]}\t{reader["Price"]}\t{reader["RoomNumber"].ToString()}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            } 
        }

        public Room GetRoom(string type)
        {
            Room room = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From rooms WHERE Email = '{type}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            room = new Room(reader["type"].ToString(), double.Parse(reader["Price"].ToString()),reader["RoomNumber"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return room is not null && room.Type.ToUpper() == type.ToUpper() ? room : null;
        }

        public void UpdateRoom(string type, double price)
        {
            try
            {
                using(var connection = new MySqlConnection(connectionString))
                {
                    var msg = $"{type} Updated Sucessfully";
                    connection.Open();
                    var queryUpdateA = $"Update rooms SET price = '{price}', where type = '{type}'";
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