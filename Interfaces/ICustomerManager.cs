using System;
using Hotel_Management_System.Model;
namespace Hotel_Management_System.Interfaces
{
    public interface ICustomerManager
    {
        public void CreateCustomer (string nextOfKin, string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber, string roomtype);
        public void UpdateCustomer ( string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber);
        public void DeleteCustomer (string id);
        public Customer GetCustomer (string email);
        public Customer Login (string email, int pin);
        public void AddMoneyToWallet (string email, double amount);
        public Customer CheckWallet (string email);
    }
}