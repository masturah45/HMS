using System;
namespace Hotel_Management_System.Menu
{
    public static class MainMenu
    {
        static CustomerMenu customerMenu = new CustomerMenu();
        static StaffMenu staffMenu = new StaffMenu();
        public static void WelcomePage()
        {
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("///////////// Welcome to five stars hotel///////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("////////////////////////////////////////////////////////");

            Console.WriteLine("Enter 1 as Staff\nEnter 2 as Customer");
            int opt = int.Parse(Console.ReadLine());
            switch(opt)
            {
                case 0 :
                Console.WriteLine("Program Closed");
                break;

                case 1 :
                Console.WriteLine("<<<<<<<<<<< Welcome to the Staff Main Menu >>>>>>>>>>>");
                staffMenu.Staff();
                break;

                case 2 :
                Console.WriteLine("<<<<<<<<<< Welcome to the Customer Main Menu >>>>>>>>>>");
                customerMenu.Customer();
                break;

                default :
                Console.WriteLine("Invalid input");
                WelcomePage();
                break;

            }
                Console.WriteLine("");
            
        }
    }
}