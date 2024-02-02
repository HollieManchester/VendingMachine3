namespace VendingMachine3
{
    namespace Domain
    {
        public class Currency
        {
            public string Symbol { get; }

            public Currency(string symbol)
            {
                Symbol = symbol;
            }
        }
    }
}
