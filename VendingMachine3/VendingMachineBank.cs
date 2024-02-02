using System;
using System.Collections.Generic;
using System.Linq;
namespace VendingMachine3.Domain { 

public class VendingMachineBank
{
    private decimal amount;
    private List<CoinDenomination> coinDenominations;
    private Currency currentCurrency;
    private Dictionary<string, int> productStock;

    public decimal Balance => amount;

    public VendingMachineBank(decimal initialAmount, Currency currentCurrency, List<CoinDenomination> initialCoinDenominations, Dictionary<string, int> initialProductStock)
    {
        amount = initialAmount;
        this.currentCurrency = currentCurrency;
        coinDenominations = initialCoinDenominations;
        productStock = initialProductStock;
    }

    public decimal InsertCoin(decimal coinValue)
    {
        var denomination = coinDenominations.FirstOrDefault(d => d.Value == coinValue && d.Count > 0);
        if (denomination != null)
        {
            amount += coinValue;
            denomination.Count--;
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
        foreach (var denomination in coinDenominations.OrderByDescending(d => d.Value))
        {
            int coinsToDispense = (int)(changeAmount / denomination.Value);
            if (coinsToDispense > 0 && denomination.Count >= coinsToDispense)
            {
                Console.WriteLine($"Dispensing {coinsToDispense} x {currentCurrency.Symbol}{denomination.Value:F2} coins");
                changeAmount -= coinsToDispense * denomination.Value;
                denomination.Count -= coinsToDispense;
            }
        }
    }

    public bool HasEnoughMoney(decimal itemPrice)
    {
        return amount >= itemPrice;
    }
}
}