using System;
using System.Collections.Generic;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces.Implementation
{
    public class RoomManager : IRoomManager
    {
        public static List<Room> listOfRooms = new List<Room>();
        public void CreateRoom( string type, double price, int roomId, int numberOfRooms)
        {    
            Random rand = new Random();
            int id = listOfRooms.Count + 1;
            string roomNumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Room room = new Room(id, type, price,roomNumber, roomId, numberOfRooms);
            listOfRooms.Add(room);
            Console.WriteLine($"thank you, {room.Type} created succesfully");
        }

        public void DeleteRoom(string type)
        {
            Room adm = GetRoom(type);
            if (adm != null)
            {
                listOfRooms.Remove(adm);
            }
            else
            {
                Console.WriteLine("Room not found");
            }
        }

        public void GetAllRooms()
        {
            foreach (var item in listOfRooms)
            {
                Console.Write($"{item.Id}\t{item.Type}\t{item.Price}\t{item.RoomNumber}");
            }
            Console.WriteLine();
        }

        public Room GetRoom(string type)
        {
            foreach (var item in listOfRooms)
            {
                if (item.Type == type)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateRoom(string type, double price, string newtype, double newprice)
        {
            Room ad = GetRoom(type);
            if (ad == null)
            {
                Console.WriteLine("Room not found");
            }
            else
            {
                ad.Type = newtype;
                ad.Price = newprice;
            }
        }
    }
}