using System.Collections.Generic;
using System.Linq;

namespace VendingMachine3.Domain
{
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

        // Add a method to replenish stock for a specific item
        public void ReplenishStock(int itemId, int quantityToAdd)
        {
            var itemToReplenish = Stock.FirstOrDefault(item => item.Id == itemId);
            if (itemToReplenish != null)
            {
                itemToReplenish.Quantity += quantityToAdd;
            }
        }
    }
}
