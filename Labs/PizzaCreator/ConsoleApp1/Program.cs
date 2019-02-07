/*
 * Lab 1
 * Chase Williamson
 * Referenced: William A. Clark (1239 Lab), Spencer Lowery (1239 Lab)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum PizzaSize { Small, Medium, Large};
enum PizzaSauce { Traditional, Garlic, Oregano };
enum PizzaCheese {Regular, Extra };
enum PizzaDelivery { Takeout, Delivery};


struct Pizzaorder
{
   public Pizzaorder (PizzaSize p1 )
   {
        Size = p1;
        Meat_Bacon = false;
        Meat_Ham = false;
        Meat_Pepperoni = false;
        Meat_Sausage = false;
        Vegg_Blackolives = false;
        Vegg_Mushrooms = false;
        Vegg_Onions = false;
        Vegg_Peppers = false;
        Sauce = PizzaSauce.Traditional;
        Cheese = PizzaCheese.Regular;
        Delivery = PizzaDelivery.Takeout;
    }


   public PizzaSize Size;
   public bool Meat_Bacon;
   public bool Meat_Ham;
   public bool Meat_Pepperoni;
   public bool Meat_Sausage;
   public bool Vegg_Blackolives;
   public bool Vegg_Mushrooms;
   public bool Vegg_Onions;
   public bool Vegg_Peppers;
   public PizzaSauce Sauce;
   public PizzaCheese Cheese;
   public PizzaDelivery Delivery;
}



namespace PizzaCreator
{
    class Program
    {
        static void Main( string[] args )
        {
            List<Pizzaorder> ListOfOrders = new List<Pizzaorder>();

            Console.WriteLine("");
            Console.WriteLine("New Order: 1");
            Console.WriteLine("Modify Order: 2");
            Console.WriteLine("Display Order: 3");
            Console.WriteLine("Quit: 4");
            Console.WriteLine("Choose menu option: ");
            string userchoice = Console.ReadLine();

            while (userchoice != "4")
            {
                if (userchoice == "1")
                {



                    Pizzaorder Temp = new Pizzaorder(PizzaSize.Small);
                    NewOrder(ref Temp);
                    ListOfOrders.Add(Temp);
                    DisplayOrder(Temp);

                } else if (userchoice == "2")
                {
                    if (ListOfOrders.Count < 1)
                    {
                        Console.WriteLine("No orders have been made yet.");
     
                    }

                  else
                    {
                        string ModifyNumber = "1";
                        Console.WriteLine("Which order would you like to modify?");
                        ModifyNumber = Console.ReadLine(); // ModifyOrder

                        while (Int32.Parse(ModifyNumber) > ListOfOrders.Count())
                        {

                            Console.WriteLine("Invalid choice. Please choice between the orders you made.");
                            ModifyNumber = Console.ReadLine();

                        }

                        Pizzaorder Temp = new Pizzaorder(PizzaSize.Small);
                        NewOrder(ref Temp);
                        ListOfOrders[Int32.Parse(ModifyNumber) -1] = Temp;
                    }


                } else if (userchoice == "3")
                {
                    DisplayOrder(ListOfOrders);


                } else
                {
                    Console.WriteLine("Invalid choice. Please choice between 1 - 4: ");


                }

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("New Order: 1");
                Console.WriteLine("Modify Order: 2");
                Console.WriteLine("Display Order: 3");
                Console.WriteLine("Quit: 4");
                Console.WriteLine("Choose menu option: ");
                userchoice = Console.ReadLine();
            }
                
            Console.Write("Thank you for using my PizzaCreator program");
    }

        

        private static void NewOrder(ref Pizzaorder Order)
        {

            // Choice size of pizza

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Small: $5");
            Console.WriteLine("2 Medium: $6.25");
            Console.WriteLine("3 Large: $8.75");
            Console.WriteLine("Please choice a size: (Small, Medium, or Large)");
            string Size = Console.ReadLine();

           

            while (true)
            {
                if (Size == "1")
                {

                    break;

                } else if (Size == "2")
                {
                    Order.Size = PizzaSize.Medium;
                    break;

                } else if (Size == "3")

                {
                    Order.Size = PizzaSize.Large;
                    break;

                } else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Small, Medium, Large ");
                    Size = Console.ReadLine();
                }
            }


            // Choice as many meats as you want

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Bacon");
            Console.WriteLine("2 Ham");
            Console.WriteLine("3 Pepperoni");
            Console.WriteLine("4 Sausage");
            Console.WriteLine("Please choice which meat(s) you want. Meats are $0.75 each (Optional).");
            Console.WriteLine("To go to next option, please enter.");
            string Meats = Console.ReadLine();


            while (Meats != "")
            {



                if (Meats == "1")
                {
                    Order.Meat_Bacon = true;
                }
                
                else if (Meats == "2")
                {
                    Order.Meat_Ham = true;
                } 
                
                else if (Meats == "3")
                {
                    Order.Meat_Pepperoni = true;
                }
                
                else if (Meats == "4")
                {
                    Order.Meat_Sausage = true;
                }
                 else
                { 
                    Console.WriteLine("Invalid choice. Please choice either: Bacon, Ham, Pepperoni, Sausage.");
                }


                Meats = Console.ReadLine();
            }


            // Choice as many vegetables you want

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Black olives");
            Console.WriteLine("2 Mushrooms");
            Console.WriteLine("3 Onions");
            Console.WriteLine("4 Peppers");
            Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
            Console.WriteLine("To go to next option, please enter.");
            string Vegetables = Console.ReadLine();

            while (Vegetables != "")
            {



                if (Vegetables == "1")
                {
                    Order.Vegg_Blackolives = true;
                } 
                
                else if (Vegetables == "2")
                {
                    Order.Vegg_Mushrooms = true;
                } 
                
                else if (Vegetables == "3")
                {
                    Order.Vegg_Onions = true;
                }
                
                else if (Vegetables == "4")
                {
                    Order.Vegg_Peppers = true;
                } 
                
                else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Black olives, Mushrooms, Onions, Peppers.");
                }

                Vegetables = Console.ReadLine();

            }



            // Choice type of sauce

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Traditional: $0");
            Console.WriteLine("2 Garlic: $1");
            Console.WriteLine("3 Oregano: $1");
            Console.WriteLine("Please choice a type of sauce: (Traditional, Garlic, or Oregano)");
            string Sauce = Console.ReadLine();

            while (true)
            {
                if (Sauce == "1")
                {

                    break;

                } 
                
                else if (Sauce == "2")
                {
                    Order.Sauce = PizzaSauce.Garlic;
                    break;

                } 
                
                else if (Sauce == "3")

                {
                    Order.Sauce = PizzaSauce.Oregano;
                    break;

                } 
                
                else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Traditional, Garlic, Oregano. ");
                    Size = Console.ReadLine();
                }
            }

            // Choice type of cheese

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Regular: $0");
            Console.WriteLine("2 Extra: $1.25");
            Console.WriteLine("Please choice a type of cheese: (Regular, or Extra)");
            string Cheese = Console.ReadLine();

            while (true)
            {
                if (Cheese == "1")
                {

                    break;

                } 
                
                else if (Cheese == "2")
                {
                    Order.Cheese = PizzaCheese.Extra;
                    break;

                } 
                
                else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Regular, or Extra ");
                    Size = Console.ReadLine();
                }
            }



            // Choice type of delivery method

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1 Take Out: $0");
            Console.WriteLine("2 Delivery: $2.50");
            Console.WriteLine("Please choice method of delivery: (Take Out, or Delivery)");
            string DeliveryMethod = Console.ReadLine();

            while (true)
            {
                if (DeliveryMethod == "1")
                {

                    break;

                }
                
                else if (DeliveryMethod == "2")
                {
                    Order.Delivery = PizzaDelivery.Delivery;
                    break;

                } 
                
                else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Take Out, or Delivery ");
                    Size = Console.ReadLine();
                }
            }

            
        }

        
        private static void DisplayOrder(List<Pizzaorder> ListOfOrders)
        {
            Console.Clear();
            Console.WriteLine();
            double TotalCost = 0.0;
            int numOrders = 0;


            foreach (Pizzaorder order in ListOfOrders)
            {
                Console.WriteLine("");
                numOrders++;
                Console.WriteLine("Order: {0}", numOrders);

                if(order.Size == PizzaSize.Small)
                {
                    Console.WriteLine("Small Pizza       $5.00");
                    TotalCost += 5.00;
                }

                else if (order.Size == PizzaSize.Medium)
                {
                    Console.WriteLine("Medium Pizza      $6.25");
                    TotalCost += 6.25;
                }

                else 
                {
                    Console.WriteLine("Large Pizza       $8.75");
                    TotalCost += 8.75;
                }

                Console.WriteLine("DeliveryMethod");

                if (order.Delivery == PizzaDelivery.Takeout)
                {
                    Console.WriteLine("Take Out");

                } 
                
                else
                {
                    Console.WriteLine("Delivery          $2.50");
                    TotalCost += 2.50;
                }

                Console.WriteLine("Meats");

                if (order.Meat_Bacon == true)
                {
                    Console.WriteLine("    Bacon         $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Ham == true)
                {
                    Console.WriteLine("    Ham           $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Pepperoni == true)
                {
                    Console.WriteLine("    Pepperoni     $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Sausage == true)
                {
                    Console.WriteLine("    Sausage       $0.75");
                    TotalCost += 0.75;
                }

                Console.WriteLine("Vegetables");

                if (order.Vegg_Blackolives == true)
                {
                    Console.WriteLine("    Blackolives   $0.50");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Mushrooms == true)
                {
                    Console.WriteLine("    Mushrooms     $0.50");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Onions == true)
                {
                    Console.WriteLine("    Onions        $0.50");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Peppers == true)
                {
                    Console.WriteLine("    Peppers       $0.50");
                    TotalCost += 0.50;
                }

                Console.WriteLine("Sauce");

                if (order.Sauce == PizzaSauce.Traditional)
                {
                    Console.WriteLine("    Traditional    ");
                   
                } 
                
                else if (order.Sauce == PizzaSauce.Garlic)
                {
                    Console.WriteLine("    Garlic        $1.00");
                    TotalCost += 1.00;
                } 
                
                else
                {
                    Console.WriteLine("    Oregano       $1.00");
                    TotalCost += 1.00;
                }

                Console.WriteLine("Cheese");

                if (order.Cheese == PizzaCheese.Regular)
                {
                    Console.WriteLine("    Regular      ");
                    
                } 
                
                
                else
                {
                    Console.WriteLine("    Extra         $1.25");
                    TotalCost += 1.25;
                }

                

                Console.WriteLine("-------------------------");
                Console.WriteLine("Total            ${0:G2}", TotalCost);
            }

            Console.WriteLine("");
            Console.ReadLine();
        }


        private static void DisplayOrder( Pizzaorder order )
        {
            Console.Clear();
            Console.WriteLine();
            double TotalCost = 0.0;



            if (order.Size == PizzaSize.Small)
            {
                Console.WriteLine("Small Pizza       $5.00");
                TotalCost += 5.00;
            } else if (order.Size == PizzaSize.Medium)
            {
                Console.WriteLine("Medium Pizza      $6.25");
                TotalCost += 6.25;
            } else
            {
                Console.WriteLine("Large Pizza       $8.75");
                TotalCost += 8.75;
            }

            Console.WriteLine("DeliveryMethod");

            if (order.Delivery == PizzaDelivery.Takeout)
            {
                Console.WriteLine("Take Out");

            } else
            {
                Console.WriteLine("Delivery          $2.50");
                TotalCost += 2.50;
            }

            Console.WriteLine("Meats");

            if (order.Meat_Bacon == true)
            {
                Console.WriteLine("    Bacon         $0.75");
                TotalCost += 0.75;
            }

            if (order.Meat_Ham == true)
            {
                Console.WriteLine("    Ham           $0.75");
                TotalCost += 0.75;
            }

            if (order.Meat_Pepperoni == true)
            {
                Console.WriteLine("    Pepperoni     $0.75");
                TotalCost += 0.75;
            }

            if (order.Meat_Sausage == true)
            {
                Console.WriteLine("    Sausage       $0.75");
                TotalCost += 0.75;
            }

            Console.WriteLine("Vegetables");

            if (order.Vegg_Blackolives == true)
            {
                Console.WriteLine("    Blackolives   $0.50");
                TotalCost += 0.50;
            }

            if (order.Vegg_Mushrooms == true)
            {
                Console.WriteLine("    Mushrooms     $0.50");
                TotalCost += 0.50;
            }

            if (order.Vegg_Onions == true)
            {
                Console.WriteLine("    Onions        $0.50");
                TotalCost += 0.50;
            }

            if (order.Vegg_Peppers == true)
            {
                Console.WriteLine("    Peppers       $0.50");
                TotalCost += 0.50;
            }

            Console.WriteLine("Sauce");

            if (order.Sauce == PizzaSauce.Traditional)
            {
                Console.WriteLine("    Traditional    ");

            } else if (order.Sauce == PizzaSauce.Garlic)
            {
                Console.WriteLine("    Garlic        $1.00");
                TotalCost += 1.00;
            } else
            {
                Console.WriteLine("    Oregano       $1.00");
                TotalCost += 1.00;
            }

            Console.WriteLine("Cheese");

            if (order.Cheese == PizzaCheese.Regular)
            {
                Console.WriteLine("    Regular      ");

            } else
            {
                Console.WriteLine("    Extra         $1.25");
                TotalCost += 1.25;
            }



            Console.WriteLine("-------------------------");
            Console.WriteLine("Total            ${0:G2}", TotalCost);


            Console.WriteLine("");
            Console.ReadLine();
        }

    }
    




}

