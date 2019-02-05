/*
 * Lab 1
 * Chase Williamson
 * Referenced: William A. Clark (1239 Lab)
 */
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
            int sizearray = 11;
            string[] choiceselections = new string[sizearray];
            int[] Prices = new int[sizearray];
          
           


            choice = GetMenuChoice();
            processchoice(choiceselections, choice);


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
        private static void processchoice( string[] choiceselections, int choice )
        {
            while (choice != 4)
            {
                switch (choice)
                {
                    case 1: NewOrder(choiceselections);

                    break;

                    case 2: ModifyOrder(choiceselections);

                    break;

                    case 3: DisplayOrder(choiceselections);

                    break;
                }
            }
            Console.Write("Thank you for using my PizzaCreator program");
        }

        private static string NewOrder( string[] choiceselections)
        {
            
            // Choice size of pizza

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
            

            switch (Size)
            {
                case "Small":
                choiceselections[0] = "Small Pizza    $5";


                break;

                case "Medium":
                choiceselections[0] = "Medium Pizza   $6.25";

                break;

                case "Large":
                choiceselections[0] = "Large Pizza    $8.75";
                

                break;
            }



            // Choice as many meats as you want

            Console.WriteLine("Bacon");
            Console.WriteLine("Ham");
            Console.WriteLine("Pepperoni");
            Console.WriteLine("Sausage");
            Console.WriteLine("Please choice which meat(s) you want. Meats are $0.75 each (Optional).");
            string Meats = Console.ReadLine();
            

            while (Meats != "" ||  Meats != "Bacon" || Meats != "Ham" || Meats != "Pepperoni" || Meats != "Sausage")
            {
                Console.WriteLine("Invalid choice. Please choice either: Bacon, Ham, Pepperoni, Sausage.");
                Meats = Console.ReadLine();
            }

             int MeatCounter = 0;

           while (Meats != "" && MeatCounter < 4)
            {
                switch (Meats)
                {
                    case "Bacon":
                    choiceselections[MeatCounter] = "Bacon          $0.75";

                    break;

                    case "Ham":
                    choiceselections[MeatCounter] = "Ham            $0.75";

                    break;

                    case "Pepperoni":
                    choiceselections[MeatCounter] = "Pepperoni       $0.75";

                    break;

                    case "Sausage":
                    choiceselections[MeatCounter] = "Sausage         $0.75";


                    break;
                }

                MeatCounter++;

                Console.WriteLine("Bacon");
                Console.WriteLine("Ham");
                Console.WriteLine("Pepperoni");
                Console.WriteLine("Sausage");
                Console.WriteLine("Please choice which meat(s) you want. Meats are $0.75 each (Optional).");

                while (Meats != "" || Meats != "Bacon" || Meats != "Ham" || Meats != "Pepperoni" || Meats != "Sausage")
                {
                    Console.WriteLine("Invalid choice. Please choice either: Bacon, Ham, Pepperoni, Sausage.");
                    Meats = Console.ReadLine();
                }
            }
            
            
            

          
            
            // Choice as many vegetables you want

            Console.WriteLine("Black olives");
            Console.WriteLine("Mushrooms");
            Console.WriteLine("Onions");
            Console.WriteLine("Peppers");
            Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
            string Vegetables = Console.ReadLine();

            while (Vegetables != "" || Vegetables != "Black olives" || Vegetables != "Mushrooms" || Vegetables != "Onions" || Vegetables != "Peppers")
            {
                Console.WriteLine("Invalid choice. Please choice either: Black olives, Mushrooms, Onions, or Peppers. ");
                Vegetables = Console.ReadLine();
            }

            int VegetableCounter = 0;

            while (Vegetables != "" && VegetableCounter < 4)
            {
                switch (Vegetables)
                {
                    case "Black olives":
                    choiceselections[VegetableCounter] = "Black olives    $0.50";

                    break;

                    case "Mushrooms":
                    choiceselections[VegetableCounter] = "Mushrooms       $0.50";

                    break;

                    case "Onions":
                    choiceselections[VegetableCounter] = "Onions          $0.50";

                    break;

                    case "Peppers":
                    choiceselections[VegetableCounter] = "Peppers         $0.50";



                    break;
                }

                VegetableCounter++;

                Console.WriteLine("Black olives");
                Console.WriteLine("Mushrooms");
                Console.WriteLine("Onions");
                Console.WriteLine("Peppers");
                Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
                

                while (Vegetables != "" || Vegetables != "Black olives" || Vegetables != "Mushrooms" || Vegetables != "Onions" || Vegetables != "Peppers")
                {
                    Console.WriteLine("Invalid choice. Please choice either: Black olives, Mushrooms, Onions, or Peppers. ");
                    Vegetables = Console.ReadLine();
                }
            }
                

            // Choice type of sauce

            Console.WriteLine("Traditional: $0");
            Console.WriteLine("Garlic: $1");
            Console.WriteLine("Oregano: $1");
            Console.WriteLine("Please choice a type of sauce: (Traditional, Garlic, or Oregano)");
            string Sauce = Console.ReadLine();

            while (Sauce != "Traditional" || Sauce != "Garlic" || Sauce != "Oregeno" )
            {
                Console.WriteLine("Invalid choice. Please choice either: Traditional, Garlic, Oregeno. ");
                Sauce = Console.ReadLine();
            }

            switch (Sauce)
            {
                case "Traditional":
                choiceselections[3] = "Traditional      ";

                break;

                case "Garlic":
                choiceselections[3] = "Garlic          $1";

                break;

                case "Oregeno":
                choiceselections[3] = "Oregano         $1";


                break;
            }

            // Choice type of cheese

            Console.WriteLine("Regular: $0");
            Console.WriteLine("Extra: $1.25");
            Console.WriteLine("Please choice a type of cheese: (Regular, or Extra)");
            string Cheese = Console.ReadLine();

            while (Cheese != "Regular" || Meats != "Extra" )
            {
                Console.WriteLine("Invalid choice. Please choice either: Regular, or Extra. ");
                Cheese = Console.ReadLine();
            }

            switch (Cheese)
            {
                case "Regular":
                choiceselections[4] = "Regular ";

                break;

                case "Extra":
                choiceselections[4] = "Extra       $2.50";

                break;
            }
             
            

            // Choice type of delivery method

            Console.WriteLine("Take Out: $0");
            Console.WriteLine("Delivery: $2.50");
            Console.WriteLine("Please choice method of delivery: (Take Out, or Delivery)");
            string DeliveryMethod = Console.ReadLine();

            while (DeliveryMethod != "Take Out" || DeliveryMethod != "Delivery" )
            {
                Console.WriteLine("Invalid choice. Please choose either: Take Out, or Delivery. ");
                DeliveryMethod = Console.ReadLine();
            }

            switch (DeliveryMethod)
            {
                case "Take Out":
                choiceselections[5] = "Take Out";

                break;

                case "Delivery":
                choiceselections[5] = "Delivery    $2.50";

                break;
            }

            return 
        }

        private static string ModifyOrder(string[] choiceselections )
        {

        }
        private static string DisplayOrder(string[] choiceselections)
        {

            Console.WriteLine();

            for (int position = 1; position < 5; position++)
            {
               
                if (choiceselections[position] != "")
                {
                    Console.WriteLine(choiceselections[position]);
                }
            }
            for (int position = 5; position < 9; position++)
            {
                

                if (choiceselections[position] != "")
                {
                    Console.WriteLine(choiceselections[position]);
                }

            }


                
        }

            
        

    }
}
