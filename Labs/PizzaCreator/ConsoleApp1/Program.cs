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

                    ListOfOrders.Add(NewOrder());


                } else if (userchoice == "2")
                {
                    ModifyOrder();


                }
                
                else if (userchoice == "3")
                {
                    DisplayOrder(ListOfOrders);


                }
                
                else
                {
                    Console.WriteLine("Invalid choice. Please choice between 1 - 4: ");


                }
                

                Console.WriteLine("New Order: 1");
                Console.WriteLine("Modify Order: 2");
                Console.WriteLine("Display Order: 3");
                Console.WriteLine("Quit: 4");
                Console.WriteLine("Choose menu option: ");
                userchoice = Console.ReadLine();
            }

            
            
                
            
            Console.Write("Thank you for using my PizzaCreator program");
        

    }

        
        

        private static Pizzaorder NewOrder()
        {


           

            // Choice size of pizza

            Console.WriteLine("Small: $5");
            Console.WriteLine("Medium: $6.25");
            Console.WriteLine("Large: $8.75");
            Console.WriteLine("Please choice a size: (Small, Medium, or Large)");
            string Size = Console.ReadLine();

            Pizzaorder Order = new Pizzaorder(PizzaSize.Small);

            while (true)
            {
                if (Size == "Small")
                {

                    break;

                } else if (Size == "Medium")
                {
                    Order.Size = PizzaSize.Medium;
                    break;

                } else if (Size == "Large")

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

            Console.WriteLine("Bacon");
            Console.WriteLine("Ham");
            Console.WriteLine("Pepperoni");
            Console.WriteLine("Sausage");
            Console.WriteLine("Please choice which meat(s) you want. Meats are $0.75 each (Optional).");
            string Meats = Console.ReadLine();


            while (Meats != "")
            {



                if (Meats == "Bacon")
                {
                    Order.Meat_Bacon = true;

                    
                }
                
                else if (Meats == "Ham")
                {
                    Order.Meat_Ham = true;

                    
                } 
                
                else if (Meats == "Pepperoni")
                {
                    Order.Meat_Pepperoni = true;

                    
                }
                
                else if (Meats == "Sausage")
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

            Console.WriteLine("Black olives");
            Console.WriteLine("Mushrooms");
            Console.WriteLine("Onions");
            Console.WriteLine("Peppers");
            Console.WriteLine("Please choice which vegetables(s) you want. Vegetables are $0.50 each (Optional).");
            string Vegetables = Console.ReadLine();

            while (Vegetables != "")
            {



                if (Vegetables == "Black olives")
                {
                    Order.Vegg_Blackolives = true;

                    

                } 
                
                else if (Vegetables == "Mushrooms")
                {
                    Order.Vegg_Mushrooms = true;

                   
                } 
                
                else if (Vegetables == "Onions")
                {
                    Order.Vegg_Onions = true;

                   
                }
                
                else if (Vegetables == "Peppers")
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

            Console.WriteLine("Traditional: $0");
            Console.WriteLine("Garlic: $1");
            Console.WriteLine("Oregano: $1");
            Console.WriteLine("Please choice a type of sauce: (Traditional, Garlic, or Oregano)");
            string Sauce = Console.ReadLine();

            while (true)
            {
                if (Sauce == "Traditional")
                {

                    break;

                } else if (Sauce == "Garlic")
                {
                    Order.Sauce = PizzaSauce.Garlic;
                    break;

                } else if (Sauce == "Oregano")

                {
                    Order.Sauce = PizzaSauce.Oregano;
                    break;

                } else
                {
                    Console.WriteLine("Invalid choice. Please choice either: Traditional, Garlic, Oregano. ");
                    Size = Console.ReadLine();
                }
            }

            // Choice type of cheese

            Console.WriteLine("Regular: $0");
            Console.WriteLine("Extra: $1.25");
            Console.WriteLine("Please choice a type of cheese: (Regular, or Extra)");
            string Cheese = Console.ReadLine();

            while (true)
            {
                if (Cheese == "Regular")
                {

                    break;

                } else if (Cheese == "Extra")
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

            Console.WriteLine("Take Out: $0");
            Console.WriteLine("Delivery: $2.50");
            Console.WriteLine("Please choice method of delivery: (Take Out, or Delivery)");
            string DeliveryMethod = Console.ReadLine();

            while (true)
            {
                if (DeliveryMethod == "Take Out")
                {

                    break;

                } else if (DeliveryMethod == "Delivery")
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

            return Order;
        }

        private static void ModifyOrder()
        {

        }
        private static void DisplayOrder(List<Pizzaorder> ListOfOrders)
        {

            Console.WriteLine();
            double TotalCost = 0.0;

            foreach (Pizzaorder order in ListOfOrders)
            {
                if(order.Size == PizzaSize.Small)
                {
                    Console.WriteLine("Small Pizza    $5.00");
                    TotalCost += 5.00;
                }

                else if (order.Size == PizzaSize.Medium)
                {
                    Console.WriteLine("Medium Pizza   $6.25");
                    TotalCost += 6.25;
                }

                else 
                {
                    Console.WriteLine("Large Pizza    $8.75");
                    TotalCost += 8.75;
                }
                       
                if(order.Meat_Bacon == true)
                {
                    Console.WriteLine("Bacon          $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Ham == true)
                {
                    Console.WriteLine("Ham            $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Bacon == true)
                {
                    Console.WriteLine("Pepperoni      $0.75");
                    TotalCost += 0.75;
                }

                if (order.Meat_Bacon == true)
                {
                    Console.WriteLine("Sausage         $0.75");
                    TotalCost += 0.75;
                }

                if (order.Vegg_Blackolives == true)
                {
                    Console.WriteLine("Blackolives     $0.75");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Mushrooms == true)
                {
                    Console.WriteLine("Mushrooms       $0.75");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Onions == true)
                {
                    Console.WriteLine("Onions          $0.75");
                    TotalCost += 0.50;
                }

                if (order.Vegg_Peppers == true)
                {
                    Console.WriteLine("Peppers         $0.75");
                    TotalCost += 0.50;
                }

                if (order.Sauce == PizzaSauce.Traditional)
                {
                    Console.WriteLine("Traditional    ");
                    TotalCost += 0.00;
                } 
                
                else if (order.Sauce == PizzaSauce.Garlic)
                {
                    Console.WriteLine("Garlic        $1.00");
                    TotalCost += 1.00;
                } 
                
                else
                {
                    Console.WriteLine("Oregano       $1.00");
                    TotalCost += 1.00;
                }

                if (order.Cheese == PizzaCheese.Regular)
                {
                    Console.WriteLine("Regluar      ");
                    TotalCost += 0.00;
                } 
                
                
                else
                {
                    Console.WriteLine("Extra        $1.25");
                    TotalCost += 1.25;
                }

                if (order.Delivery == PizzaDelivery.Takeout)
                {
                    Console.WriteLine("Take Out"    );
                    TotalCost += 0.00;
                } 
                
                
                else
                {
                    Console.WriteLine("Delivery     $2.50");
                    TotalCost += 2.50;
                }
            }

                
        }

            
        

    }
}
