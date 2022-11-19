using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;
using MySql.Data.MySqlClient;

namespace HMS.Interfaces.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        // public static List<Customer> listOfCustomers = new List<Customer>();
        public string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";
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

        public void CheckWallet(string email, double amount)
        {
            Customer ad = GetCustomer(email);
            if (ad != null)
            {
                if (ad.Wallet > 0 )
                {
                    Console.WriteLine("You have checked your balance");
                }

            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }

        public void CreateCustomer(string nextOfKin, string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, int roomtype)
        {

            Random rand = new Random();
            // int id = listOfCustomers.Count + 1;
            double wallet = 0;
            string customernumber = "MTC/CTM" + rand.Next(100, 999).ToString();
            Customer customer = new Customer(wallet, nextOfKin, customernumber,firstName, lastName, email, password, dateOfBirth, phoneNumber, roomtype);
            // listOfCustomers.Add(customer);
            var query = $"insert into customers (firstName, lastName, Email, Password, DateOfBirth, NextOfKin, PhoneNumber, Roomtype)values ('{firstName}', '{lastName}', '{email}', '{password}', '{dateOfBirth}', '{nextOfKin}', '{phoneNumber}', {roomtype})";
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Thank you {customer.FirstName}, your customer number is {customer.CustomerNumber}");
        }

        public void DeleteCustomer(string email)
        {
           var customer = GetCustomer(email);
            if (customer != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{customer.FirstName} {customer.LastName} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From customers WHERE Email = '{email}'", connection))
                        {
                            var reader = command.ExecuteNonQuery();
                            System.Console.WriteLine(deleteSuccessMsg);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void GetAllCustomer()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From customers", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["wallet"]}\t{reader["NextOfKin"]}\t{reader["CustomerNumber"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["password"].ToString()}\t{reader["dateOfBirth"].ToString()}\t{reader["phoneNumber"].ToString()}\t{reader["Roomtype"].ToString()}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public Customer GetCustomer(string email)
        {
           Customer customer = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From customers WHERE Email = '{email}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customer = new Customer(double.Parse(reader["wallet"].ToString()), reader["nextOfKin"].ToString(),reader["customerNumber"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["password"].ToString(), DateTime.Parse(reader["dateOfBirth"].ToString()), reader["phoneNumber"].ToString(), Convert.ToInt32(reader["roomtype"]));
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("This is error");
                System.Console.WriteLine(ex.Message);
            }
            return customer is not null && customer.Email.ToUpper() == email.ToUpper() ? customer : null;
        }

        public Customer Login(string email, string password)
        {
            Customer customer = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var querr = $"select * from customers where email = '{email}' and password = '{password}';";
                    using (var command = new MySqlCommand(querr, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customer = new Customer(double.Parse(reader["wallet"].ToString()),reader["nextOfKin"].ToString(), reader["customerNumber"].ToString(), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["password"].ToString(), DateTime.Parse(reader["dateOfBirth"].ToString()), reader["phoneNumber"].ToString(), int.Parse(reader["roomtype"].ToString()));
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return customer is not null && customer.Email.ToUpper() == email.ToUpper() && customer.Password == password ? customer : null;
        }

        


        // public Customer RescheduleBooking( int roomtype, int bookingdate, string duration)
        // {
        //     foreach (var item in listOfCustomers)
        //     {
        //         if (item.bookingDate == bookingdate)
        //         {
        //             return item;
        //         }
        //     }
        //     return null;
        // } 

        public void UpdateCustomer(string email, string firstName, string lastName, string nextOfKin)
        {
            try
            {
                using(var connection = new MySqlConnection(connectionString))
                {
                    var msg = $"{email} Updated Sucessfully";
                    connection.Open();
                    var queryUpdateA = $"Update customers SET firstName = '{firstName}', lastName = '{lastName}', nextOfKin = '{nextOfKin}' where email = '{email}'";
                    using (var command = new MySqlCommand(queryUpdateA, connection))
                    {
                        var yes = command.ExecuteNonQuery();
                        System.Console.WriteLine(msg);
                    }
                }
            }
            catch (System.Exception ex)
            {
                
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}