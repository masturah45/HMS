using System;
using HMS.Model;

namespace HMS.Interfaces
{
    public interface IStaffManager
    {
        public void CreateStaff (string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, string roles);
        public void UpdateStaff (string email, string firstName, string lastName, string roles);
        public void DeleteStaff (string email);
        public Staff GetStaff (string email);
        public void GetAllStaff();
        public Staff Login (string email, string password);
    }
}