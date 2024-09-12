using Godot;
using System;

public partial class CpsContainer : HBoxContainer
{
	public Label _cpsLabel;
	public override void _Ready()
	{
		_cpsLabel = GetNode<Label>("_cpsLabel");
	}

	public void AddCashCPSTotal(int power)
	{
		GameManager.Instance.totalCPS += power;
		addCashCPStoLabel();
	}


    public void addCashCPStoLabel()
	{
		_cpsLabel.Text = GameManager.Instance.totalCPS.ToString();
	}
}
