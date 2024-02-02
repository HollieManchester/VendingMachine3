namespace VendingMachine3.Domain { 
    public class VendingMachineItem
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }

        public VendingMachineItem(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
