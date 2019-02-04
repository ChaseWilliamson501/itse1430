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
            processchoice(choice);
           
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
        private static void processchoice( int choice )
        {
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1: NewOrder();

                    break;

                    case 2: ModifyOrder();

                    break;

                    case 3: DisplayOrder();

                    break;
                }
            }
            Console.Write("Thank you for using my PizzaCreator program");
        }

        private static string NewOrder()
        {
            int sizearray = 8;
            string[] choiceselections = new string[sizearray];

            Console.WriteLine("Small: $5");
            Console.WriteLine("Medium: $6.25");
            Console.WriteLine("Large: $8.75");
            Console.WriteLine("Please choice a size: (Small, Medium, or Large)");
            string Size = Console.ReadLine();

            while (Size != "Small" || Size != "Medium" || Size != "Large")
            {
                Console.WriteLine("Invalid choice. Please choice either: Small, Medium, Large ");
                Size = Console.ReadLine();
            }

            Console.WriteLine("Bacon");
            Console.WriteLine("Ham");
            Console.WriteLine("Pepperoni");
            Console.WriteLine("Sausage");
            Console.WriteLine("Please choice which meat(s) you want. Meats are $0.75 each (Optional).");
            string Meats = Console.Read();


            Console.WriteLine("Black olives");
            Console.WriteLine("Mushrooms");
            Console.WriteLine("Onions");
            Console.WriteLine("Peppers");
            Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
            string Vegetables = Console.Read();


            Console.WriteLine("Black olives");
            Console.WriteLine("Mushrooms");
            Console.WriteLine("Onions");
            Console.WriteLine("Peppers");
            Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
            string Vegetables = Console.Read();

            Console.WriteLine("Traditional: $0");
            Console.WriteLine("Garlic: $1");
            Console.WriteLine("Oregano: $1");
            Console.WriteLine("Please choice a type of sauce: (Traditional, Garlic, or Oregano)");
            string Sauce = Console.Read();

           
            Console.WriteLine("Regular: $0");
            Console.WriteLine("Extra: $1.25");
            Console.WriteLine("Please choice a type of cheese: (Regular, or Extra)");
            string Cheese = Console.Read();

            Console.WriteLine("Take Out: $0");
            Console.WriteLine("Delivery: $2.50");
            Console.WriteLine("Please choice method of delivery: (Take Out, or Delivery)");
            string DeliveryMethod = Console.Read();

            return 
        }

        private static string ModifyOrder()
        {

        }
        private static string DisplayOrder()
        {

        }

    }
}
