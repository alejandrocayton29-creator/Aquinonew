using System;
using System.Collections.Generic;


namespace ShoppingCartApp
{
    internal class Program
    {
        static List<CartItem> cart = new List<CartItem>();

        public class CartItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public double TotalPrice => Quantity * Price;
        }

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nShopping Cart Menu");
                Console.Write("\n");
                Console.WriteLine("1. Add Item to Cart");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Exit");
                Console.Write("\n");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddToCart();
                        break;
                    case "2":
                        DisplayCart();
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting system...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }


        static void AddToCart()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter price per item: ");
            double price = double.Parse(Console.ReadLine());

            cart.Add(new CartItem { Name = name, Quantity = quantity, Price = price });
            Console.WriteLine($"{quantity} x {name} added to cart.");
        }

        static void DisplayCart()
        {
            Console.WriteLine("\nYour Cart");
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            double grandTotal = 0;
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Quantity} x {item.Name} @ PHP {item.Price:F2} each = PHP {item.TotalPrice:F2}");

                grandTotal += item.TotalPrice;
            }
            Console.WriteLine($"Total: ₱{grandTotal:F2}");

        }
    }
}