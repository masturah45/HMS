using HMS.Model;

namespace HMS.Interfaces
{
    public interface IRoomManager
    {
        public void CreateRoom (string type, double price);
        public void UpdateRoom (string type, double price);
        public void DeleteRoom (string roomNumber);
        public Room GetRoom (string roomNumber);
        public void GetAllRooms ();
    }
}