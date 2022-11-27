using System;
using HMS.Interfaces;
using HMS.Interfaces.Implementation;
using HMS.Model;

namespace HMS.Menu
{
    public class CustomerMenu
    {
        ICustomerManager customerManager = new CustomerManager();
        IBookingManager bookingManager = new BookingManager();
        IRoomManager roomManager = new RoomManager();

        public void Customer()
        {
            Console.WriteLine("Enter 1 to Register\nEnter 2 to Login\nEnter 3 to go back to main menu");
            // customerManager.ReadFromFile();
            bool exit = false;
            while (!exit)
            {
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.Write("Invalid Input, Enter 1, 2 or 3: ");
                }
                switch (option)
                {
                    case 1:
                        RegisterCustomer();
                        break;

                    case 2:
                        LoginCustomer();
                        break;

                    case 3:
                        MainMenu.WelcomePage();
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        return;
                }

            }

        }
        public void RegisterCustomer()
        {
            Console.WriteLine("Welcome");

            Console.Write("Enter your firstname: ");
            string fName = Console.ReadLine();

            Console.Write("Enter your lastname: ");
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
            Console.Write("Enter your nextOfKin: ");                                                        
            string NOK = Console.ReadLine();

            Console.WriteLine("Enter your roomtype: ");
            string roomtype = Console.ReadLine();
            

            customerManager.CreateCustomer(NOK, fName, lName, email, password, DOB, phoneNumber, roomtype);
            Customer();
        }

        public void LoginCustomer()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Customer customer = customerManager.Login(email, password);

            if (customer != null)
            {
                Console.WriteLine("login successful");
                CustomerSubMenu(customer);
            }
            else
            {
                Console.WriteLine("wrong email or pin");
                Customer();
            }
        }

        public void CustomerSubMenu(Customer customer)
        {
            int flag = 0;
            do
            {
                Console.WriteLine("\nEnter 1 for booking\nEnter 2 to AddMoneyToWallet\nEnter 3 to reschedule booking\nEnter 4 to CheckWallet\nEnter 0 to go back to the main menu");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateBooking(customer);
                        break;


                    case 2:
                        AddMoneyToWallet(customer);
                        break;

                    // case 3:
                    //     RescheduleBooking();
                    //     break;

                    case 4:
                        CheckWallet();
                        break;

                    case 0:
                        MainMenu.WelcomePage();
                        break;

                    default:
                        Console.Write("Invalid Input");
                        break;

                }

                Console.WriteLine("\nEnter 1 to go through the program again\nEnter 2 to exit the program");
                flag = int.Parse(Console.ReadLine());
            } while (flag == 1);
        }

        public void CreateBooking(Customer customer)
        {

            Console.Write("Enter your checkInDate(yyyy-mm-dd):  ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your checkOutDate(yyyy-mm-dd): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your roomtype: ");
            string roomtype = Console.ReadLine();
            

            DateTime bookingdate = DateTime.UtcNow;
            // Console.Write("Enter your duration: ");
            int duration = ((checkOutDate - checkInDate).Days) + 1;
            bool ischecked = true;

            bookingManager.CreateBooking(bookingdate, checkInDate, checkOutDate, ischecked, roomtype, duration);
        }

        public void AddMoneyToWallet(Customer customer)
        {
            Console.Write("Enter your amount: ");
            double amount = double.Parse(Console.ReadLine());

            customerManager.AddMoneyToWallet(customer.Email, amount);
            Console.WriteLine($"{amount} has been successfully added to your wallet");
        }

        public void CheckWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Emter your amount: ");
            double amount = double.Parse(Console.ReadLine());

            customerManager.CheckWallet(email, amount);
        }
        // public void RescheduleBooking()
        // {

        //     Console.Write("Enter your roomtype:  ");
        //     int roomtype = int.Parse(Console.ReadLine());

        //     Console.Write("Enter your bookingDate(yyyy-mm-dd): ");
        //     int bookingdate = int.Parse(Console.ReadLine());

        //     Console.Write("Enter your duration:");
        //     string duration = (Console.ReadLine());

        //     customerManager.RescheduleBooking(roomtype, bookingdate, duration);
        // }
    }
}