using System;
namespace Hotel_Management_System.Model
{
    public class Staff : User
    {
        public int Roles {get; set;}
        public string Staffnumber {get;set;}

        public Staff(int roles, string staffnumber,  int id, string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber): base (id, firstName, lastName, email, pin, dateOfBirth, phoneNumber)
        {
            Roles = roles;
            Staffnumber = staffnumber;
        }
    }
}