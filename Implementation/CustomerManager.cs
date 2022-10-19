using System;
using System.Collections.Generic;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        public static List<Customer> listOfCustomers = new List<Customer>();
        public void AddMoneyToWallet(string email, double amount)
        {
            Customer adm = GetCustomer(email);
            if (adm != null)
            {
                adm.Wallet += amount;
                Console.WriteLine($"{amount} successfully added to wallet and balance is {adm.Wallet}");
                
            }
            else
            {
                Console.WriteLine("customer not found");
            }
        }

        public Customer CheckWallet(string email)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email)
                {
                    Console.WriteLine("You have successfully checked your balance");
                }
            }
            return null;
        }

        public void CreateCustomer( string nextOfKin, string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber, string roomtype)
        {
            
            Random rand = new Random();
           int id = listOfCustomers.Count + 1;
           double wallet = 0;
           string customernumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Customer customer = new Customer(wallet, nextOfKin, customernumber, id, firstName, lastName, email, pin, dateOfBirth, phoneNumber, roomtype);
            listOfCustomers.Add(customer);
            Console.WriteLine($"thank you {customer.FirstName}, your wallet balance is credited with {customer.Wallet}");
        }

        public void DeleteCustomer(string id)
        {
            Customer customer = GetCustomer(id);
            if (customer != null)
            {
                listOfCustomers.Remove(customer);
                Console.WriteLine("You have successfully deleted these customer");
            }
            else
            {
                Console.WriteLine("customer not found");
            }
        }

        public Customer GetCustomer(string email)
        {
            foreach (var customer in listOfCustomers)
            {
                if (customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Login(string email, int pin)
        {
            foreach (var item in listOfCustomers)
            {
                if (item.Email == email && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateCustomer( string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber)
        {
            Customer ad = GetCustomer(email);
            if (ad == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                ad.FirstName = firstName;
                ad.LastName = lastName;
                ad.DateOfBirth = dateOfBirth;
                ad.PhoneNumber = phoneNumber;
            }
            listOfCustomers[ad.Id - 1] = ad;
        }
    }
}