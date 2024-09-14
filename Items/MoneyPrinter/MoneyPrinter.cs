using Godot;
using System;
using System.Transactions;

public partial class MoneyPrinter : Item
{
    public MoneyPrinter()
    {
        Name = "MoneyPrinter";
        Power = 1; //Level1 = 2, Level2 = 4, Level3 = 8
        Cost = 1;
        CostTrend = 2;
        PowerTrend = 2;
    }

}
