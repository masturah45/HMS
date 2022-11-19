using HMS.Model;

namespace HMS.Interfaces
{
    public interface IRoomManager
    {
        public void CreateRoom (string type, double price);
        public void UpdateRoom (string type, double price);
        public void DeleteRoom (string type);
        public Room GetRoom (string type);
        public void GetAllRooms ();
    }
}