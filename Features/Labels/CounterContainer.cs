using Godot;
using System;

public partial class CounterContainer : HBoxContainer
{
    public CounterContainer _counterContainer;
	public Label _counterLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_counterLabel = GetNode<Label>("_counterLabel");
	}

    public void AddCash()
    {
        //Refactored to find the clicker via the itemDict
        
        GameManager.Instance._counter += GameManager.Instance.itemDictionary["ClickPower"].Power;

        _counterLabel.Text = (GameManager.Instance._counter.ToString());
    }

    public void AddCashCPStoCounter()
    {
        GameManager.Instance._counter += GameManager.Instance.totalCPS;
        _counterLabel.SetText(GameManager.Instance._counter.ToString());
    }


    public void RemoveCash(int cost)
    {
        GameManager.Instance._counter -= cost;
        _counterLabel.SetText(GameManager.Instance._counter.ToString());
    }
}
