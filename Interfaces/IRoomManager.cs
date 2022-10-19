using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces
{
    public interface IRoomManager
    {
        public void CreateRoom (string type, double price, int roomId, int numberOfRooms);
        public void UpdateRoom (string type, double price, string newtype, double newprice);
        public void DeleteRoom (string type);
        public Room GetRoom (string type);
        public void GetAllRooms ();
    }
}