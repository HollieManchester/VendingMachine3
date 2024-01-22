using System;
using System.Collections.Generic;
using System.Linq;

public class VendingMachineBank
{
    private decimal amount;
    private Dictionary<decimal, int> coinDenominations;
    private Currency currentCurrency;
    private Dictionary<string, int> productStock;

    public VendingMachineBank(decimal initialAmount, Currency currentCurrency, Dictionary<string, int> initialProductStock)
    {
        amount = initialAmount;
        this.currentCurrency = currentCurrency;
        InitializeCoinDenominations();
        productStock = initialProductStock;
    }

    private void InitializeCoinDenominations()
    {
        coinDenominations = new Dictionary<decimal, int>
        {
            { 2.00m, 10 },
            { 1.00m, 10 },
            { 0.50m, 10 },
            { 0.20m, 10 },
            { 0.10m, 10 },
            { 0.05m, 10 },
            { 0.02m, 10 },
            { 0.01m, 10 }
        };
    }

    public decimal InsertCoin(decimal coinValue)
    {
        if (coinDenominations.ContainsKey(coinValue) && coinDenominations[coinValue] > 0)
        {
            amount += coinValue;
            coinDenominations[coinValue]--;
            Console.WriteLine($"Inserted {currentCurrency.Symbol}{coinValue:F2}. Current balance: {currentCurrency.Symbol}{amount:F2}");
            return amount;
        }
        else
        {
            Console.WriteLine($"Invalid coin or insufficient change available for {currentCurrency.Symbol}{coinValue:F2}");
            return amount;
        }
    }

    public decimal GiveChange(decimal itemPrice)
    {
        decimal changeAmount = amount - itemPrice;

        if (changeAmount >= 0)
        {
            Console.WriteLine($"Change given: {currentCurrency.Symbol}{changeAmount:F2}");
            DispenseChange(changeAmount);
            amount = 0;
        }
        else
        {
            Console.WriteLine($"Insufficient funds. Please insert more coins.");
        }

        return changeAmount;
    }

    private void DispenseChange(decimal changeAmount)
    {
        foreach (var denomination in coinDenominations.OrderByDescending(d => d.Key))
        {
            int coinsToDispense = (int)(changeAmount / denomination.Key);
            if (coinsToDispense > 0 && coinDenominations[denomination.Key] >= coinsToDispense)
            {
                Console.WriteLine($"Dispensing {coinsToDispense} x {currentCurrency.Symbol}{denomination.Key:F2} coins");
                changeAmount -= coinsToDispense * denomination.Key;
                coinDenominations[denomination.Key] -= coinsToDispense;
            }
        }
    }

    public bool HasEnoughMoney(decimal itemPrice)
    {
        return amount >= itemPrice;
    }
}
