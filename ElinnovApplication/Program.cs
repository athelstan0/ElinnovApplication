using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        var inventory = new InventoryManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== Inventory Management ===");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Product Quantity");
            Console.WriteLine("4. List All Products");
            Console.WriteLine("5. Get Total Inventory Value");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine() ?? "";

                    int quantity;
                    while (true)
                    {
                        Console.Write("Enter Quantity: ");
                        if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 0)
                            break;
                        Console.WriteLine("Quantity must not be negative.");
                    }

                    decimal price;
                    while (true)
                    {
                        Console.Write("Enter Price: ");
                        if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out price) && price >= 0)
                            break;
                        Console.WriteLine("Price must not be negative.");
                    }

                    inventory.AddProduct(new Product
                    {
                        Name = name,
                        QuantityInStock = quantity,
                        Price = price
                    });
                    break;

                case "2":
                    Console.Write("Enter Product ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine() ?? "0");
                    inventory.RemoveProduct(removeId);
                    break;

                case "3":
                    Console.Write("Enter Product ID to update: ");
                    int updateId = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Enter new quantity: ");
                    int newQty = int.Parse(Console.ReadLine() ?? "0");

                    inventory.UpdateProduct(updateId, newQty);
                    break;

                case "4":
                    inventory.ListProducts();
                    break;

                case "5":
                    Console.WriteLine($"Total Inventory Value: {inventory.GetTotalValue():C}");
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Exiting... Goodbye!");
    }
}
