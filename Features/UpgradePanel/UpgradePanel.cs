using Godot;
using System;
using System.Reflection.Emit;

public partial class UpgradePanel : Control
{

    public Button _purchaseClicker;
    public Button _purchaseAutoClicker;

    public override void _Ready()
    {
        //Clicker SetUp
        _purchaseClicker = GetNode<Button>("_purchaseClicker");
        _purchaseClicker.Text = $"{GameManager.Instance._clicker.Name} Upgrade\nCost: {GameManager.Instance._clicker.Cost}\nLevel: {GameManager.Instance._clicker.Level}";
        _purchaseClicker.Pressed += () => PurchaseUpgrade(GameManager.Instance._clicker, _purchaseClicker);

        //Auto Clicker SetUp
        _purchaseAutoClicker = GetNode<Button>("_purchaseAutoClicker");
        _purchaseAutoClicker.Text = $"{GameManager.Instance._autoClicker.Name} Upgrade\nCost: {GameManager.Instance._autoClicker.Cost}\nLevel: {GameManager.Instance._autoClicker.Level}";
        _purchaseAutoClicker.Pressed += () => PurchaseUpgrade(GameManager.Instance._autoClicker, _purchaseAutoClicker);

    }


    private void PurchaseUpgrade(Item item, Button button)
    {
        if (GameManager.Instance._counter >= item.Cost)
        {
            int cost = item.Cost;
            item.Upgrade();
            GameManager.Instance.removeClicks(cost);
            cost = item.Cost;
            int level = item.Level;
            button.SetText($"{item.Name} Upgrade\nCost: {cost}\nLevel: {level}");
        }
        else
        {
            GD.Print("not enough clicks");
        }
    }
}


