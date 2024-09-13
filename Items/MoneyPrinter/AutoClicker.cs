using Godot;
using System;
using System.Transactions;

public partial class MoneyPrinter : Item
{
    public MoneyPrinter()
    {
        Name = "MoneyPrinter";
        Power = 2;
        Cost = 1;
        CostTrend = 2;
        PowerTrend = 2;
    }

}
