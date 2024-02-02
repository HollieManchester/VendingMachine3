using System;
using System.Collections.Generic;
using System.Linq;

public class CoinDenomination
{
    public decimal Value { get; }
    public int Count { get; set; }

    public CoinDenomination(decimal value, int count)
    {
        Value = value;
        Count = count;
    }
}


