using Godot;
using System;

public partial class Clicker : Item
{

    public Clicker()
    {
        Name = "ClickPower";
        Level = 1;
        Power = 1;
        Cost = 10;
        CostTrend = 2;
        PowerTrend = 2;
    }

    public override void Upgrade()
    {
        Power *= PowerTrend;
        Cost *= CostTrend;
        Level++;
        GD.Print("Upgrade called");
        //Call updateButton.text 
    }

}
