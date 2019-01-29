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
            var literal1 = "Hello \"Bob\" ";
            var path = "C:\\Windows\\System32";
            path += "\\Temp";
            var path2 = @"C:\Windows\System32";
   
            //1. String Concat
            Console.WriteLine("Name:" + name);

            //2. String Format
            string str = String.Format("Price: {0:C}", price);
            Console.WriteLine(str);
            //Console.WriteLine("Price: $" + price);

            //3. Function overload - just calls String.Format
            Console.WriteLine("Publisher: {0}", publisher);

            //4. Concatenation
            String.Concat("Owned?", " ", owned);
            Console.WriteLine(str);
            //Console.WriteLine("Owned? " + owned);

            //5.Interpolation
            //Console.WriteLine("Completed? " + completed);
            //Console.WriteLine("COmpleted? {0}", completed);
            Console.WriteLine($"Completed? {completed}");

            // Convert to a string
            string strPrice = price.ToString("C");
            string strLiteral = "Hello".ToString();
            //ReadBoolean("Hello").ToString();
            10.ToString(); // "10"

            // Is string empty
            string input = null;
            int lengh = input.Length;
            bool isEmpty;

            // 1.
            //if (input != null)
            //    isEmpty = input.Length == 0;
            //else
            //    isEmpty = true;

            // 2.
            isEmpty = (input != null) ? input.Length == 0 : true;

            // 3.
            isEmpty = input == " ";

            // 4.
            isEmpty = input == String.Empty;

            // 5.
            isEmpty = String.IsNullOrEmpty(input);

            //Comparison
            bool areEqual = "Hello" == "hello";
            areEqual = String.Compare("Hello", "hello", true) == 0;

            // Conversion
            input = input.ToLower();
            input = input.ToUpper();

            //Manipulation
            bool starsWith = input.StartsWith("http:");
            bool endsWith = input.StartsWith("/");

            input = input.PadLeft(10);
            input = input.PadRight(10, '-');

            input = input.TrimStart();
            input = input.TrimEnd();
            input = input.Trim();
        }

        private static bool ReadBoolean ( string message )
        {
            do
            {
                Console.WriteLine(message);
                string result = Console.ReadLine().ToUpper();

                //Validate it is a boolean

                if (result == "Y")
                    return true;
                if (result == "N")
                    return false;

                //switch (result)
                //{
                //    case "Y":
                //    case "y": return true; 

                //    case "N": 
                //    case "n": return false; 

                //    default: Console.WriteLine("Enter Y or y"); break;
                //};

                //if (result == "Y" || "y"
                //if (result == "Y" || result == "y")
                //if (result == "y")
                // return true;
                //if (result == "n")
                // return false;
                    

                Console.WriteLine("Enter Y or No")
            } while (true);
   

        }

        //bool TryParse( string, out decimal result );

        private static decimal ReadDecimal (string message)
        {
            while (true)
            {

                Console.WriteLine(message);
                string value = Console.ReadLine();


                //decimal result;
                //if (Decimal.TryParse(value, out result))
                if (Decimal.TryParse(value, out decimal result))
                    return result;


                Console.WriteLine("Enter a vallid decimal value");
                
            };
        }

        private static string name;
        private static string publisher;
        private static decimal price;
        private static bool owned;
        private static bool completed;

    }
}
