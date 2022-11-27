using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;
using MySql.Data.MySqlClient;

namespace HMS.Interfaces.Implementation
{
    public class StaffManager : IStaffManager
    {
        public string connectionString = "Server=localhost;Database=hms;Uid=root;Pwd=masturah";
        public void CreateStaff(string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, string roles)
        {

            Random rand = new Random();
            string staffnumber = "FIVE/STARS" + rand.Next(100, 999).ToString();
            Staff staff = new Staff(roles, staffnumber, firstName, lastName, email, password, dateOfBirth, phoneNumber);
            var query = $"insert into hms.staffs (firstName, lastName, Email, Password, DateOfBirth, PhoneNumber, Roles, staffNumber) value ('{firstName}', '{lastName}', '{email}', '{password}', '{dateOfBirth}', '{phoneNumber}', '{roles}', '{staffnumber}');";
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
            Console.WriteLine($"thank you mr {staff.FirstName}, you are the {staff.Roles} and your staff identity number is {staffnumber}");
        }

        public void DeleteStaff(string email)
        {
           var staff = GetStaff(email);
            if (staff != null)
            {
                try
                {
                    var deleteSuccessMsg = $"{staff.FirstName} {staff.LastName} Successfully deleted. ";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new MySqlCommand($"DELETE From staffs WHERE Email = '{email}'", connection))
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
                Console.WriteLine("Staff not found.");
            }
        }

        public void GetAllStaff()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("select * From staffs", connection))
                    {
                        var reader = command.ExecuteReader();
                      while (reader.Read())
                        {
                            Console.WriteLine($"{reader["roles"]}\t{reader["staffNumber"]}\t{reader["id"].ToString()}\t{reader["firstName"].ToString()}\t{reader["lastName"].ToString()}\t{reader["email"].ToString()}\t{reader["password"].ToString()}\t{reader["dateOfBirth"].ToString()}\t{reader["phoneNumber"].ToString()}");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }    
        }

        public Staff GetStaff(string email)
        {
            Staff staff = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand($"select * From staffs WHERE Email = '{email}'", connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            staff = new Staff(reader["roles"].ToString(), reader["staffNumber"].ToString(),reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["password"].ToString(), DateTime.Parse(reader["dateOfBirth"].ToString()), reader["phoneNumber"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return staff is not null && staff.Email.ToUpper() == email.ToUpper() ? staff : null;
        }

        public Staff Login(string email, string password)
        {
            Staff staff = null;
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var querr = $"select * from staffs where email = '{email}' and password = '{password}';";
                    using (var command = new MySqlCommand(querr, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            staff = new Staff(reader["roles"].ToString(),reader.GetString(2), reader["firstName"].ToString(), reader["lastName"].ToString(), reader["email"].ToString(), reader["password"].ToString(), DateTime.Parse(reader["dateOfBirth"].ToString()), reader["phoneNumber"].ToString());
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            return staff is not null && staff.Email.ToUpper() == email.ToUpper() && staff.Password == password ? staff : null;
        }

        public void UpdateStaff(string email, string firstName, string lastName, string roles)
        {
            try
            {
                using(var connection = new MySqlConnection(connectionString))
                {
                    var msg = $"{email} Updated Sucessfully";
                    connection.Open();
                    var queryUpdateA = $"Update staffs SET firstName = '{firstName}', lastName = '{lastName}', roles = '{roles}' where email = '{email}'";
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