using System;
using Hotel_Management_System.Interfaces;
using Hotel_Management_System.Interfaces.Implementation;
using Hotel_Management_System.Model;

namespace Hotel_Management_System.Menu
{
    public class CustomerMenu
    {
        ICustomerManager customerManager = new CustomerManager();
        IBookingManager bookingManager = new BookingManager();
        IRoomManager roomManager = new RoomManager();

        public void Customer()
        {
            Console.WriteLine("Enter 1 to Register\nEnter 2 to Login\nEnter 3 to go back to main menu");
            bool exit = false;
            while (!exit)
            {
                int option;
                while (!int.TryParse(Console.ReadLine(), out option ))
                {
                    Console.Write("Invalid Input, Enter 1, 2 or 3: ");
                }
                switch(option)
            {
                case 1:
                    RegisterCustomer();
                    break;

                case 2:
                    LoginCustomer();
                    break;

                case 3 :
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

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your nextOfKin: ");
            string NOK = Console.ReadLine();

            Console.Write("Enter your roomtype: ");
            string roomtype = Console.ReadLine();

            customerManager.CreateCustomer(NOK, fName, lName, email, pin, DOB, phoneNumber, roomtype);
            Customer();
        }

        public void LoginCustomer()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your pin: ");
            int pin = int.Parse(Console.ReadLine());

            Customer customer = customerManager.Login(email, pin);

            if (customer != null)
            {
                Console.WriteLine("login successful");
                CustomerSubMenu();
            }
            else
            {
                Console.WriteLine("wrong email or pin");
            }
        }

        public void CustomerSubMenu()
        {
            int flag = 0;
            do
            {   
                Console.WriteLine("\nEnter 1 for booking\nEnter 2 to update customer\nEnter 3 to AddMoneyToWallet\nEnter 4 to CheckWallet");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1 :
                    CreateBooking();
                    break;

                    case 2 :
                    UpdateCustomer();
                    break;

                    case 3 :
                    AddMoneyToWallet();
                    break;

                    case 4 :
                    CheckWallet();
                    break;

                    default :
                    Console.Write("Invalid Input");
                    break;

                }

                Console.WriteLine("\nEnter 1 to go through the program again\nEnter 2 to exit the program");
                flag = int.Parse(Console.ReadLine());   
            } while(flag == 1); 

                
                    

        }

        public void CreateBooking()
        {
            Console.Write("Enter your bookingDate(yyyy-mm-dd): ");
            DateTime bookingdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your checkInDate(yyyy-mm-dd):  ");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your checkOutDate(yyyy-mm-dd): ");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your roomId: ");
            string roomId = Console.ReadLine();

            Console.WriteLine("Enter your roomtype () 2 - QueenSize, 3 - Presidential, 4 - DoubleSize, 5 - NormalSize  : ");
            int roomtype;
            while (!int.TryParse(Console.ReadLine(), out roomtype))
            {
                Console.WriteLine("Invalid input; Enter; Enter RoomType () 2 - QueenSize, 3 - Presidential, 4 - DoubleSize, 5 - NormalSize ");
            }

            Console.Write("Enter your duration: ");
            string duration = Console.ReadLine();
            bool isAvailable = true;

            bookingManager.CreateBooking(bookingdate, checkInDate, checkOutDate, roomId,isAvailable, roomtype, duration);
        }

        public void UpdateCustomer()
        {
            Console.Write("Enter your firstName: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter your lastName: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your dateOfBirth(yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter your phoneNumber: ");
            string phoneNumber = Console.ReadLine();

            customerManager.UpdateCustomer(firstName, lastName, email, dateOfBirth, phoneNumber);
        }

        public void AddMoneyToWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your amount: ");
            double amount = double.Parse(Console.ReadLine());

            customerManager.AddMoneyToWallet(email, amount);
        }

        public void CheckWallet()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("You have successfully checked your balance");

            customerManager.CheckWallet(email);
        }
    }
}