using System;
namespace Hotel_Management_System.Model
{
    public class User
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public int Pin {get; set;}
        public DateTime DateOfBirth {get; set;}
        public string PhoneNumber {get; set;}

        public User(int id, string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Pin = pin;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }   
}