namespace VendingMachine3.Domain
{
    public class CoinDenomination
    {
        public decimal Value { get; }
        public int Quantity { get; set; }

        public CoinDenomination(decimal value, int quantity)
        {
            Value = value;
            Quantity = quantity;
        }
    }
}
