using Godot;
using System;

public partial class ClickPower : Item
{

    public ClickPower()
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
        Power *= PowerTrend; //1 + 1*2 = 3
        Cost *= CostTrend;
        Level++;
        GD.Print("Upgrade called from ClickPower");
        //Call updateButton.text 
    }

}
