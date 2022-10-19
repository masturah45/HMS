using System;
using System.Collections.Generic;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Interfaces.Implementation
{
    public class StaffManager : IStaffManager
    {
        public static List<Staff> listOfStaffs = new List<Staff>();
        public void CreateStaff( string firstName, string lastName, string email, int pin, DateTime dateOfBirth, string phoneNumber, int roles)
        {
            
            Random rand = new Random();
            int id = listOfStaffs.Count + 1;
            string staffnumber = "MTC/AD" + rand.Next(100, 999).ToString();
            Staff staff = new Staff(roles, staffnumber, id, firstName, lastName, email, pin, dateOfBirth, phoneNumber);
            listOfStaffs.Add(staff);
            Console.WriteLine($"thank you mr {staff.FirstName}, you are the {staff.Roles} and your staff identity number is {staffnumber}");
        }

        public void DeleteStaff(string id)
        {
            Staff adm = GetStaff(id);
            if(adm != null)
            {
                listOfStaffs.Remove(adm);
                Console.WriteLine("You have successfully deleted these staff");
            }
            else
            {
                Console.WriteLine("staff not found");
            }
        }

        public Staff GetStaff(string email)
        {
            foreach (var item in listOfStaffs)
            {
                if(item.Email == email)
                {
                    return item;
                }
            }
            return null;
        }

        public Staff Login(string email, int pin)
        {
            foreach (var item in listOfStaffs)
            {
                if (item.Email == email && item.Pin == pin)
                {
                    return item;
                }
            }
            return null;
        }

        public void UpdateStaff(string firstName, string lastName, string email, DateTime dateOfBirth, string phoneNumber)
        {
            Staff ad = GetStaff(email);
            if(ad == null)
            {
                Console.WriteLine("Staff not found");
            }
            else
            {
                ad.FirstName = firstName;
                ad.LastName = lastName;
                ad.PhoneNumber = phoneNumber;
                ad.DateOfBirth = dateOfBirth;
            }
            listOfStaffs[ad.Id - 1] = ad;
        }
    }
}