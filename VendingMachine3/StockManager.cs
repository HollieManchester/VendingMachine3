// StockManager.cs
using System.Collections.Generic;
using System.Linq;

public class StockManager
{
    public List<VendingMachineItem> Stock { get; }

    public StockManager(List<VendingMachineItem> initialStock)
    {
        Stock = initialStock;
    }

    public void AddStockItem(int id, string name, decimal price, int quantity)
    {
        var newItem = new VendingMachineItem(id, name, price, quantity);
        Stock.Add(newItem);
    }

    public bool RemoveStockItem(int id)
    {
        var itemToRemove = Stock.FirstOrDefault(item => item.Id == id);
        if (itemToRemove != null)
        {
            Stock.Remove(itemToRemove);
            return true;
        }
        return false;
    }

    public void ReplenishStock(Dictionary<int, int> stockCounts)
    {
        foreach (var stockCount in stockCounts)
        {
            var item = Stock.FirstOrDefault(i => i.Id == stockCount.Key);
            if (item != null)
            {
                item.Quantity += stockCount.Value;
            }
        }
    }
}
