namespace Hotel_Management_System.Model
{
    public class Room
    {
        public int Id {get; set;}
        public string Type {get; set;}
        public double Price {get; set;}
        public string RoomNumber {get; set;}
        public int RoomId {get; set;}
        public int NumberOfRooms {get; set;}

        public Room (int id, string type, double price, string roomNumber, int roomId, int numberOfRooms)
        {
            Id = id;
            Type = type;
            Price = price;
            RoomNumber = roomNumber;
            RoomId = roomId;
            NumberOfRooms = numberOfRooms;
        }
    }
}