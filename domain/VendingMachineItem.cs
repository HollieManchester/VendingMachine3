// VendingMachineItem.cs
public class VendingMachineItem
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; set; }  // Make the set accessor public

    public VendingMachineItem(int id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
