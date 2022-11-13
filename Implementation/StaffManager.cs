using System;
using System.Collections.Generic;
using System.IO;
using HMS.Model;

namespace HMS.Interfaces.Implementation
{
    public class StaffManager : IStaffManager
    {
        public string FileDirect = "./Files";
        public static List<Staff> Staffs = new List<Staff>();
        public string FilePath = "./Files/staff.txt";
        public void CreateStaff(string firstName, string lastName, string email, string password, DateTime dateOfBirth, string phoneNumber, int roles)
        {

            Random rand = new Random();
            int id = Staffs.Count + 1;
            string staffnumber = "MTC/AD" + rand.Next(100, 999).ToString();
            Staff staff = new Staff(roles, staffnumber, id, firstName, lastName, email, password, dateOfBirth, phoneNumber);
            Staffs.Add(staff);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                writer.WriteLine(staff.ConvertToFileFormat());
            }

            Console.WriteLine($"thank you mr {staff.FirstName}, you are the {staff.Roles} and your staff identity number is {staffnumber}");
        }

        public void DeleteStaff()
        {
            Console.Write("Enter email of staff to delete: ");
            string email = Console.ReadLine().Trim();
            foreach (var item in Staffs)
            {
                if (item.Email == email)
                {
                    Staffs.Remove(item);
                    ReWriteFile();
                    break;
                }
            }
        }

        public void GetAllStaff()
        {
            foreach (var item in Staffs)
            {
                Console.WriteLine($"{item.Roles}+++{item.Staffnumber}+++{item.Id}+++{item.FirstName}+++{item.LastName}+++{item.Email}+++{item.Password}+++{item.DateOfBirth}+++{item.PhoneNumber}");
            }
        }

        public Staff GetStaff(string email)
        {
            foreach (var item in Staffs)
            {
                if (item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Staff Login(string email, string password)
        {
            foreach (var item in Staffs)
            {
                if (item.Email == email && item.Password == password)
                {
                    return item;
                }
            }
            return null;
        }

        public void ReadFromFile()
        {
            if (!Directory.Exists(FileDirect))
            {
                Directory.CreateDirectory(FileDirect);
            }
            if (!File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.CreateNew);
                fs.Close();
            }
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (reader.Peek() > -1)
                {
                    string staffinfo = reader.ReadLine();
                    Staffs.Add(Staff.ConvertToStaff(staffinfo));
                }
            }
        }

        public void ReWriteFile()
        {
            File.WriteAllText(FilePath, string.Empty);
            using (StreamWriter writer = new StreamWriter(FilePath, append: true))
            {
                foreach (var staff in Staffs)
                {
                    writer.WriteLine(staff.ConvertToFileFormat());
                }
            }
        }

        public void UpdateStaff()
        {
            Console.Write("Enter email of Staff to Update: ");
            string email = Console.ReadLine().Trim();
            Staff staffToUpdate = GetStaff(email);
            if (staffToUpdate != null)
            {
                Console.Write("Update First Name: ");
                string firstName = Console.ReadLine().Trim();
                staffToUpdate.FirstName = firstName;

                Console.Write("Update Last Name: ");
                string lastName = Console.ReadLine().Trim();
                staffToUpdate.LastName = lastName;

                Console.Write("Update Roles:  ");
                int roles = int.Parse(Console.ReadLine().Trim());
                staffToUpdate.Roles = roles;
                ReWriteFile();
                Console.WriteLine("staff updated successfully");
            }

            else
            {
                Console.WriteLine("staff not found");
            }
        }
    }
}