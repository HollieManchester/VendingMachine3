    using System;
    using System.Collections.Generic;
namespace VendingMachine3.Domain { 
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

            List<CoinDenomination> initialCoinDenominations = GetInitialCoinDenominations();

            VendingMachineBank bank = new VendingMachineBank(0, selectedCurrency, initialCoinDenominations, new Dictionary<string, int>());
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
                // Menu implementation remains the same
            }
        }

        // Updated method to get initial coin denominations
        static List<CoinDenomination> GetInitialCoinDenominations()
        {
            Console.WriteLine("\nEnter initial coin denominations:");

            List<CoinDenomination> coinDenominations = new List<CoinDenomination>();
            decimal[] denominations = { 2.00m, 1.00m, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m };

            foreach (var denomination in denominations)
            {
                Console.Write($"Enter quantity of {denomination:C2} coins: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    coinDenominations.Add(new CoinDenomination(denomination, quantity));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid quantity.");
                    return GetInitialCoinDenominations();
                }
            }

            return coinDenominations;
        }
    }
}
