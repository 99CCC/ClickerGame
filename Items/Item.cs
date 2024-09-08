using Godot;
using System;

public abstract class Item
{
    public static Item Instance;
    public string Name { get; set; }
    public int Power { get; set; }
    public int Cost { get; set; }
    public int Level { get; set; }
    public int CostTrend { get; set; }
    public int PowerTrend { get; set; }

    public Item()
    {
        Name = "Item";
        Power = 0;
        Cost = 0;
        Level = 0;
        CostTrend = 0;
        PowerTrend = 0;
        Instance = this;
    }

    public virtual void Upgrade()
    {
        Power *= PowerTrend;
        Cost *= CostTrend;
        Level++;
        GameManager.Instance._clickObject.updateCPS(Power);
        GD.Print("Upgrade called");
    }

}
