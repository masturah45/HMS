using System;
using HMS.Interfaces;
using HMS.Interfaces.Implementation;
using HMS.Model;

namespace HMS.Menu
{
    public class StaffMenu
    {
        IStaffManager staffManager = new StaffManager();
        ICustomerManager customerManager = new CustomerManager();
        IBookingManager bookingManager = new BookingManager();
        IRoomManager roomManager = new RoomManager();

        public void Staff()
        {
            bool isPrev = false;
            while (!isPrev)
            {
                Console.WriteLine("Enter 1 to register\nEnter 2 to login\nEnter 0 for Main Menu");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    RegisterStaff();
                }
                else if (choice == 2)
                {
                    LoginStaff();
                }
                else if (choice == 0)
                {
                    isPrev = true;
                }
                else
                {
                    Console.WriteLine("Invaid Input");
                }
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

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            DateTime DOB;//= DateTime.Parse(Console.ReadLine());
            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            while (!DateTime.TryParse(Console.ReadLine(), out DOB))
            {
                Console.Write("Enter your date again: ");
            }
            Console.WriteLine("Enter your roles (1 - Manager 2 - Receptionist 3 - Accountant)");
            int roleOption;
            while (!int.TryParse(Console.ReadLine(), out roleOption))
            {
                Console.WriteLine("Invalid input; Enter; Enter Staff Role (1 - Manager 2 - Receptionist 3 - Accountant)");
            }
            string roles = "";
            switch (roleOption)
            {
                case 1:
                    roles = "Manager";
                    break;

                case 2:
                    roles = "Receptionist";
                    break;

                case 3:
                    roles = "Accountant";
                    break;
            }

            staffManager.CreateStaff(fName, lName, email, password, DOB, phoneNumber, roles);
            Staff();
        }

        public void LoginStaff()
        {
            Console.WriteLine("<<<<<< Main Menu <<<<<<< Login >>>>>>>>>");

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Staff staff = staffManager.Login(email, password);

            if (staff != null)
            {
                Console.WriteLine("login successful");
                StaffSubMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin");
                Staff();
            }
        }

        public void StaffSubMenu()
        {
            Console.WriteLine("\nEnter 1 to update staffs\nEnter 2 to create staff\nEnter 3 to get the available rooms\nEnter 4 to update customer\nEnter 5 to delete customer\nEnter 6 to create room\nEnter 7 to delete staff\nEnter 8 to view all staffs\nEnter 9 to view all custoomers\nEnter 10 to view all rooms\nEnter 11 to delete rooms\nEnter 12 to update booking\nEnter 13 to delete booking\nEnter 0 to go back to main menu");
             bool exit = false;
             while (!exit)
             {
                int option;

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Input, Enter 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 or 0");
                }
                switch (option)
                {
                    case 1:
                        UpdateStaff();
                        break;

                    case 2:
                        CreateStaff();
                        break;

                    case 3:
                        GetAvailableRooms();
                        break;

                    case 4:
                        UpdateCustomer();
                        break;

                    case 5:
                        DeleteCustomer();
                        break;

                    case 6:
                        CreateRoom();
                        break;

                    case 7 :
                        DeleteStaff();
                        break;

                    case 8 :
                        staffManager.GetAllStaff();
                        break;

                    case 9 :
                        customerManager.GetAllCustomer();
                        break;

                    case 10 :
                        roomManager.GetAllRooms();
                        break;

                    case 11 :
                    DeleteRoom();
                        break;

                    case 12 :
                    UpdateBooking();
                        break;

                    case 13 :
                    DeleteBooking();
                        break;

                    case 0:
                        MainMenu.WelcomePage();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        StaffSubMenu();
                        break;
                }
             }
        }

        public void UpdateStaff()
        {
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine().Trim();
            var staff = staffManager.GetStaff(email);
            if (staff != null)
            {
                Console.Write("Enter new staff first Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter new staff last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter new Roles: ");
                string roles = Console.ReadLine();

                staffManager.UpdateStaff(email, firstName, lastName, roles);

                Console.WriteLine($"{email} successfully updated. ");
            }
            else
            {
                Console.WriteLine($"{email} not found");
            }
        }

        public void CreateStaff()
        {
            Console.Write("Enter your firstname: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your lastname: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter your roles (1 - Manager 2 - Receptionist 3 - Accountant)");
            int roleOption;
            while (!int.TryParse(Console.ReadLine(), out roleOption))
            {
                Console.WriteLine("Invalid input; Enter; Enter Staff Role (1 - Manager 2 - Receptionist 3 - Accountant)");
            }
            string roles = "";
            switch (roleOption)
            {
                case 1:
                    roles = "Manager";
                    break;

                case 2:
                    roles = "Receptionist";
                    break;

                case 3:
                    roles = "Accountant";
                    break;
            }

            staffManager.CreateStaff(firstName, lastName, email, password, dateOfBirth, phoneNumber, roles);
            Staff();
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter your Email: ");
            string email = Console.ReadLine().Trim();
            var customer = customerManager.GetCustomer(email);
            if (customer != null)
            {
                Console.Write("Enter new customer first Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter new customer last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Enter new nextOfKin: ");
                string nextOfKin = Console.ReadLine();
                

                customerManager.UpdateCustomer(email, firstName, lastName, nextOfKin);

                Console.WriteLine($"{email} successfully updated. ");
            }
            else
            {
                Console.WriteLine($"{email} not found");
            }
        }

        public void DeleteCustomer()
        {
            System.Console.Write("Enter your email: ");
            string email = Console.ReadLine().Trim();

            customerManager.DeleteCustomer(email);

            System.Console.WriteLine($"{email} successfully deleted");
        }

        public void DeleteStaff()
        {
            System.Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine().Trim();

            staffManager.DeleteStaff(email);

            System.Console.WriteLine($"{email} successfully deleted");
        }

        public void GetAvailableRooms()
        {
            Console.WriteLine("Enter your roomtype: ");
            string roomtype = Console.ReadLine();

            Console.Write("Enter your bookingDate(yyyy-mm-dd): ");
            DateTime bookingDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your duration: ");
            int duration = Convert.ToInt32(Console.ReadLine());

            Console.Write("You have successfully booked a room for yourself");

            bookingManager.GetAvailableRooms(roomtype, bookingDate, duration);
        }

        public void CreateRoom()
        {
            Console.Write("Enter your type: ");
            string type = Console.ReadLine();

            Console.Write("Enter your price: ");
            double price = double.Parse(Console.ReadLine());

            roomManager.CreateRoom(type, price);
        }

        public void DeleteRoom()
        {
            System.Console.Write("Enter roomNumber to delete room: ");
            string roomNumber = Console.ReadLine();

            roomManager.DeleteRoom(roomNumber);

            System.Console.WriteLine($"{roomNumber} successfully deleted");
        }

        public void UpdateBooking()
        {
            Console.Write("Enter the bookingdate to Update: ");
            string bookingNumber = Console.ReadLine().Trim();
            Booking bookingDateToUpdate = bookingManager.GetBooking(bookingNumber);
            if (bookingDateToUpdate != null)
            {
                Console.Write("Update checkInDate: ");
                DateTime checkInDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingDateToUpdate.CheckInDate = checkInDate;

                Console.Write("Update checkOutDate: ");
                DateTime checkOutDate = DateTime.Parse(Console.ReadLine().Trim());
                bookingDateToUpdate.CheckOutDate = checkOutDate;

                int duration = ((checkOutDate - checkInDate).Days) + 1;
                bool ischecked = true;
                bookingDateToUpdate.Duration = duration;
                Console.WriteLine("booking updated successfully");
            }

            else
            {
                Console.WriteLine("booking not found");
            }
        }

        public void DeleteBooking()
        {
            System.Console.Write("Enter bookingnumber to delete booking: ");
            string bookingNumber = Console.ReadLine();

            bookingManager.DeleteBooking(bookingNumber);

            System.Console.WriteLine($"{bookingNumber} successfully deleted");
        }
    }
}