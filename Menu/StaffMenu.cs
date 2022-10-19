using System;
using Hotel_Management_System.Interfaces;
using Hotel_Management_System.Interfaces.Implementation;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Menu
{
    public class StaffMenu
    {
        IStaffManager staffManager = new StaffManager();
        ICustomerManager customerManager = new CustomerManager();
        IBookingManager bookingManager = new BookingManager();

        public void Staff()
        {
            Console.WriteLine("Enter 1 to Register\nEnter 2 to Login");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    RegisterStaff();
                    break;

                case 2:
                    LoginStaff();
                    break;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }

        public void RegisterStaff()
        {
            Console.WriteLine("Welcome: ");

            Console.Write("Enter your firstName: ");
            string fName = Console.ReadLine();

            Console.Write("Enter your lastName: ");
            string lName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime DOB = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter Role () 2 - Receptionist, 3 - Security, 4 - Cleaner, 5 - Accountant, 6 - Cook, 7 - Driver: ");
            int roles;
            while (!int.TryParse(Console.ReadLine(), out roles))
            {
                Console.WriteLine("Invalid input; Enter; Enter Staff Role ()2 - Receptionist, 3 - Security, 4 - Cleaner, 5 - Accountant, 6- Cook, 7 - Driver ");
            }
            staffManager.CreateStaff(fName, lName,email, pin, DOB, phoneNumber, roles);
            Staff();
        }

         public void LoginStaff()
        {
            Console.WriteLine("<<<<<< Main Menu <<<<<<< Login >>>>>>>>>");
            
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Staff staff = staffManager.Login(email, pin);

            if (staff != null)
            {
                Console.WriteLine("login successful");
                StaffSubMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin");
            }
        }

        public void StaffSubMenu()
        {
            Console.WriteLine("\nEnter 1 to update rooms\nEnter 2 to create staff\nEnter 3 to get the available rooms\nEnter 0 to go back to main menu");
            bool exit = false;
            while (!exit)
            {
                int option;

                while (!int.TryParse(Console.ReadLine(), out option ))
                {
                    Console.WriteLine("Invalid Input, Enter 1, 2, 3 or 0");
                }
                switch(option)
                {
                    case 1 :
                    UpdateStaff();
                    break;

                    case 2 :
                    CreateStaff();
                    break;

                    case 3 :
                    GetAvailableRooms();
                    break;

                    case 0 :
                    MainMenu.WelcomePage();
                    break;

                    default :
                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
        }

        public void UpdateStaff()
        {
            Console.Write("Enter your firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            staffManager.UpdateStaff(firstName, lastName, email, dateOfBirth, phoneNumber);
            Staff();
        }

        public void CreateStaff()
        {
            Console.Write("Enter your firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your roles () 2 - Receptionist, 3 - Security, 4 - Cleaner, 5 - Accountant, 6 - Cook, 7 - Driver ");
            int roles;
            while (!int.TryParse(Console.ReadLine(), out roles))
            {
                Console.WriteLine("Invalid input; Enter; Enter Staff Role ()2 - Receptionist, 3 - Security, 4 - Cleaner, 5 - Accountant, 6- Cook, 7 - Driver ");
            }

            staffManager.CreateStaff(firstName, lastName, email, pin, dateOfBirth, phoneNumber, roles);
            Staff();
        }

        public void GetAvailableRooms()
        {
            Console.WriteLine("Enter your roomtype () 2 - QueenSize, 3 - Presidential, 4 - DoubleSize, 5 - NormalSize  : ");
            int roomtype;
            while (!int.TryParse(Console.ReadLine(), out roomtype))
            {
                Console.WriteLine("Invalid input; Enter; Enter RoomType () 2 - QueenSize, 3 - Presidential, 4 - DoubleSize, 5 - NormalSize ");
            }

            Console.Write("Enter your bookingDate(yyyy-mm-dd): ");
            DateTime bookingDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your duration: ");
            string duration = Console.ReadLine();

            Console.Write("You have successfully booked a room for yourself");

            bookingManager.GetAvailableRooms(roomtype, bookingDate, duration);
        }
    }
}