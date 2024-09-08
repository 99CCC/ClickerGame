using Godot;
using System;


    public  partial class ClickObject : Control
    {
        public Button _clickObject;
        public Label _counterLabel;
        public Label _cpsLabel;    

    public override void _Ready()
    {
        _clickObject = GetNode<Button>("_button");
        _counterLabel = GetNode<Label>("_label");
        _cpsLabel = GetNode<Label>("_cps");

        _clickObject.Pressed += clickObjectPressed;

    }


    private void clickObjectPressed()
        {
        GD.Print("label: ", _counterLabel.Text," from ClickObjectPressed");
        GameManager.Instance.AddClicks();
        }

    public void updateCPS(int power)
    {
        GameManager.Instance.totalCPS += power;
        _cpsLabel.SetText($"CPS:\n{GameManager.Instance.totalCPS.ToString()}");
    }
    }
