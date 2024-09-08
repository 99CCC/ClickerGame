using Godot;
using System;
using System.Transactions;

public partial class AutoClicker : Item
{
    public AutoClicker()
    {
        Name = "Auto Clicker";
        Power = 1;
        Cost = 15;
        CostTrend = 2;
        PowerTrend = 2;
    }

}
