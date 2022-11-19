using System;
namespace HMS.Model
{
    public class Staff : User
    {
        public string Roles {get; set;}
        public string Staffnumber {get;set;}

        public Staff(string roles, string staffnumber, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber): base (firstName, lastName, email, password, dateOfBirth, phoneNumber)
        {
            Roles = roles;
            Staffnumber = staffnumber;
        }
    }
}