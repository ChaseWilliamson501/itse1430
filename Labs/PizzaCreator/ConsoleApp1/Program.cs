using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main( string[] args )
        {
            int choice;   
            choice = GetMenuChoice();
            //processchoice(choice);
        }

        private static int GetMenuChoice()
        {
            
                Console.WriteLine("New Order: 1");
                Console.WriteLine("Modify Order: 2");
                Console.WriteLine("Display Order: 3");
                Console.WriteLine("Quit: 4");
                Console.WriteLine("Choose menu option: ");
                var userchoice = Console.Read();

             while (userchoice < 1 || userchoice > 4)
            {
                Console.WriteLine("Invalid choice. Please choice between 1 - 4: " );
                userchoice = Console.Read();
            }

            return userchoice;

        }
        //private static void processchoice(string choice)
        //{
        //    while (choice != "4")
        //    {

        //    }
        //}
    }
}

