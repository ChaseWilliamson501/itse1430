/*
 * Lab 1
 * Your Name
 */
using System;

namespace HelloWorld
{
    // Single line comment
    class Program
    {
        static void Main( string[] args )
        {
            NewGame();
            DisplayGame();
        }

        private static void CSharpBasic()
        {
            string name;

            Console.WriteLine("Enter your name:");
            name = Console.ReadLine();

            Console.Write("Hello ");
            Console.WriteLine(name);
        }

        private static void NewGame ()
        {
            Console.WriteLine("Enter the name: ");
            name = Console.ReadLine();

            //Console.WriteLine("Do you own this? ");
            //string owned = Console.ReadLine();
            owned = ReadBoolean("Owned (Y(NY)");

            //Console.WriteLine("Price? ");
            //string price = Console.ReadLine();
            price = ReadDecimal("Price?");

            Console.WriteLine("Publisher? ");
            publisher = Console.ReadLine();

            //Console.WriteLine("Completed? ");
            //string completed = Console.ReadLine();
            completed = ReadBoolean("completed(Y(N)?");        }

        private static void DisplayGame ()
        {
            string literal1 = "Hello \"Bob\" ";
            string path = "C:\\Windows\\System32";
            string path2 = @"C:\Windows\System32";
   
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Price: " + price);
            Console.WriteLine("Publiisher: " + publisher);
            Console.WriteLine("Owned? " + owned);
            Console.WriteLine("Completed? " + completed);
        }

        private static bool ReadBoolean ( string message )
        {
            Console.WriteLine(message);
            string result = Console.ReadLine();

            //Validate it is a boolean
            //HACK: Fix this expression
            if (result == "Y")
                return true;
            if (result == "y")
                return true;
            if (result == "N")
                return false;
            if (result == "n")
                return false;

            //TODO: add validation
            return false;

        }

        //bool TryParse( string, out decimal result );

        private static decimal ReadDecimal (string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();

            //decimal result;
            //if (Decimal.TryParse(value, out result))
            if(Decimal.TryParse(value, out decimal result))
                return result;

            return 0;

       
        }

        private static string name;
        private static string publisher;
        private static decimal price;
        private static bool owned;
        private static bool completed;

    }
}
