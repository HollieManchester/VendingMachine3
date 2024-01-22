using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("================================");
        Console.WriteLine("Welcome to the Vending Machine!");
        Console.WriteLine("================================");

        Console.Write("Enter the currency symbol: ");
        string currencySymbol = Console.ReadLine();

        Currency selectedCurrency = new Currency(currencySymbol);

        // Initialise the stock with initial counts
        Dictionary<string, int> initialProductStock = new Dictionary<string, int>
        {
            {"Cola", 10},
            {"Crisps", 10},
            {"Sprite", 10}
        };

        VendingMachineBank bank = new VendingMachineBank(0, selectedCurrency, initialProductStock);
        List<VendingMachineItem> initialStock = new List<VendingMachineItem>
        {
            new VendingMachineItem(1, "Cola", 1.50m, 10),
            new VendingMachineItem(2, "Crisps", 1.25m, 10),
            new VendingMachineItem(3, "Sprite", 1.00m, 10)
        };

        StockManager stockManager = new StockManager(initialStock);
        VendingMachine vendingMachine = new VendingMachine(bank, stockManager, selectedCurrency);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Display Stock");
            Console.WriteLine("2. Insert Coin");
            Console.WriteLine("3. Choose an item");
            Console.WriteLine("4. Add stock");
            Console.WriteLine("5. Remove stock");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        vendingMachine.DisplayStock();
                        break;
                    case 2:
                        Console.Write("Enter coin value: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal coinValue))
                        {
                            vendingMachine.InsertCoin(coinValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid coin value. Please enter a valid decimal value.");
                        }
                        break;
                    case 3:
                        vendingMachine.DisplayStock();
                        Console.Write("Enter the item number you want to purchase: ");
                        if (int.TryParse(Console.ReadLine(), out int itemId))
                        {
                            vendingMachine.SelectItem(itemId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid item number.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nAdding a new stock item:");
                        Console.Write("Enter item ID: ");
                        int newId = int.Parse(Console.ReadLine());
                        Console.Write("Enter item name: ");
                        string newName = Console.ReadLine();
                        Console.Write($"Enter item price ({selectedCurrency.Symbol}): ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter item quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());

                        vendingMachine.AddStockItem(newId, newName, newPrice, newQuantity);

                        Console.WriteLine("\nUpdated stock:");
                        vendingMachine.DisplayStock();
                        break;
                    case 5:
                        Console.WriteLine("\nRemoving stock item:");
                        Console.Write("Enter item ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeItemId))
                        {
                            vendingMachine.RemoveStockItem(removeItemId);
                            Console.WriteLine("\nUpdated stock:");
                            vendingMachine.DisplayStock();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid item number.");
                        }
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
        }
    }
}
