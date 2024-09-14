using Godot;
using System;

public abstract class Item
{
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
    }

    public virtual void Upgrade(Item item)
    {
        //Item retrievedItem = GameManager.Instance.itemDictionary[item.Name];

        item.Power *= item.PowerTrend;
        item.Cost *= item.CostTrend;
        item.Level++;
        GameManager.Instance._cpsContainer.AddCashCPSTotal(item.Power);
        //GD.Print($"Upgrade called Name: {retrievedItem.Name}, Power: {retrievedItem.Power}, Cost: {retrievedItem.Cost} Powertrend: {retrievedItem.PowerTrend} ");
        GD.Print($"Upgrade called Name: {item.Name}, Power: {item.Power}, Cost: {item.Cost} Powertrend: {item.PowerTrend} ");
    }

}
