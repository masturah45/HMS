using System;
namespace HMS.Model
{
    public class Customer : User
    {
        public double Wallet {get; set;}
        public string NextOfKin {get; set;}
        public string CustomerNumber {get; set;}
        public string RoomType {get; set;}

        public Customer(double wallet, string nextOfKin, string customernumber,  string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, string roomtype): base (firstName, lastName, email, password, dateOfBirth, phoneNumber)
        {
            Wallet = wallet;
            NextOfKin = nextOfKin;
            CustomerNumber = customernumber; 
            RoomType = roomtype;
        }
    }
}