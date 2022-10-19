using System;
namespace Hotel_Management_System.Model
{
    public class Customer : User
    {
        public double Wallet {get; set;}
        public string NextOfKin {get; set;}
        public string CustomerNumber {get; set;}
        public string RoomType {get; set;}

        public Customer(double wallet, string nextOfKin, string customernumber, int id, string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber, string roomtype): base (id,firstName, lastName, email, pin, dateOfBirth, phoneNumber)
        {
            Wallet = wallet;
            NextOfKin = nextOfKin;
            CustomerNumber = customernumber; 
            RoomType = roomtype;
        }
    }
}