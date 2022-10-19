using System;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces
{
    public interface IStaffManager
    {
        public void CreateStaff (string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber, int roles);
        public void UpdateStaff (string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber);
        public void DeleteStaff (string id);
        public Staff GetStaff (string email);
        public Staff Login (string email, int pin);
    }
}