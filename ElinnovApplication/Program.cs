using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main() // This is the main method where the program starts
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
                        Console.WriteLine("Quantity must be a positive number.");
                    }

                    decimal price;
                    while (true)
                    {
                        Console.Write("Enter Price: ");
                        if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out price) && price >= 0)
                            break;
                        Console.WriteLine("Price must be a positive number.");
                    }

                    inventory.AddProduct(new Product
                    {
                        Name = name,
                        QuantityInStock = quantity,
                        Price = price
                    });
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    //Console.Clear(); //I can't make console.clear work somehow...
                    Console.WriteLine(new string('\n', 50));
                    break;

                case "2":
                    try
                    {
                        Console.Write("Enter Product ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            inventory.RemoveProduct(removeId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid product ID. Please enter a valid integer.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    Console.WriteLine(new string('\n', 50));
                    break;

                case "3":
                    try
                    {
                        Console.Write("Enter Product ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.Write("Enter new quantity: ");
                            if (int.TryParse(Console.ReadLine(), out int newQty))
                            {
                                Console.Write("Enter new price: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                                {
                                    inventory.UpdateProduct(updateId, newQty, newPrice);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid price. Please enter a valid decimal number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity. Please enter a valid integer.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid product ID. Please enter a valid integer.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    Console.WriteLine(new string('\n', 50));
                    break;
                case "4":
                    inventory.ListProducts();
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    Console.WriteLine(new string('\n', 50));
                    break;

                case "5":
                    Console.WriteLine($"Total Inventory Value: {inventory.GetTotalValue():C}");
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    Console.WriteLine(new string('\n', 50));
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                    // Console.Clear();
                    Console.WriteLine(new string('\n', 50));
                    break;
            }
        }
        Console.WriteLine("Exiting... Goodbye!");
    }
}
