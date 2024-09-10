using Godot;
using System;

public partial class CpsContainer : HBoxContainer
{
	public Label _cpsLabel;
	public override void _Ready()
	{
		_cpsLabel = GetNode<Label>("_cpsLabel");
	}

	public void AddCookieCPSTotal(int power)
	{
		GameManager.Instance.totalCPS += power;
		addCookieCPStoLabel();
	}


    public void addCookieCPStoLabel()
	{
		_cpsLabel.Text = GameManager.Instance.totalCPS.ToString();
	}
}
