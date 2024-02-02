// VendingMachine.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class VendingMachine
{
    private VendingMachineBank bank;
    private StockManager stockManager;
    private Currency currentCurrency;
    public decimal Balance => bank.Balance;


    public decimal Balance { get; private set; }

    public VendingMachine(VendingMachineBank bank, StockManager stockManager, Currency currentCurrency)
    {
        this.bank = bank;
        this.stockManager = stockManager;
        this.currentCurrency = currentCurrency;
        Balance = 0;
    }

    public void DisplayStock()
    {
        Console.WriteLine("Available items:");
        foreach (var item in stockManager.Stock.Where(item => item.Quantity > 0))
        {
            Console.WriteLine($"{item.Id}. {item.Name} - {currentCurrency.Symbol}{item.Price:F2} - Stock: {item.Quantity}");
        }
    }

    public decimal InsertCoin(decimal coinValue)
    {
        Balance = bank.InsertCoin(coinValue);
        return Balance;
    }

    public decimal SelectItem(int itemId)
    {
        var selectedItem = stockManager.Stock.FirstOrDefault(item => item.Id == itemId && item.Quantity > 0);
        if (selectedItem != null)
        {
            Console.WriteLine($"You have selected: {selectedItem.Name} - {currentCurrency.Symbol}{selectedItem.Price:F2}");

            if (bank.HasEnoughMoney(selectedItem.Price))
            {
                if (selectedItem.Quantity > 0)
                {
                    decimal change = bank.GiveChange(selectedItem.Price);
                    selectedItem.Quantity--; // Decrease the quantity of the selected item
                    return change;
                }
                else
                {
                    Console.WriteLine("Selected item is out of stock.");
                    return 0m;
                }
            }
            else
            {
                Console.WriteLine("Insufficient funds. Please insert more coins.");
                return 0m;
            }
        }
        else
        {
            Console.WriteLine("Invalid item selection or out of stock.");
            return 0m;
        }
    }


    public void AddStockItem(int id, string name, decimal price, int quantity)
    {
        stockManager.AddStockItem(id, name, price, quantity);
    }

    public bool RemoveStockItem(int id)
    {
        return stockManager.RemoveStockItem(id);
    }

    public void ReplenishStock(Dictionary<int, int> stockCounts)
    {
        stockManager.ReplenishStock(stockCounts);
    }
}

