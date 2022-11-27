namespace HMS.Model
{
    public class Room
    {
        public string Type {get; set;}
        public double Price {get; set;}
        public string RoomNumber {get; set;}

        public Room ( string type, double price, string roomNumber)
        {
            Type = type;
            Price = price;
            RoomNumber = roomNumber;
        }
    }
}