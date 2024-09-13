using Godot;
using System;

public partial class CashButton : Sprite2D
{
	public Sprite2D _cashButton;
	public Label _label;
	private Tween _tween;

	public override void _Ready()
	{

		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{	
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
			{
				if (GetRect().HasPoint(ToLocal(mouseEvent.Position)))
				{
					GameManager.Instance._cashButton.clickAnimation();
					GameManager.Instance._counterContainer.AddCash();
                }
				
			}
		}

	}

	public void clickAnimation()
	{
		_tween = GetTree().CreateTween();
		var sprite = GameManager.Instance._cashButton;

		_tween.TweenProperty(sprite, "scale", new Vector2(0.95F, 0.95F), 0.075f);
		_tween.TweenProperty(sprite, "scale", Vector2.One, 0.075f);
    }

}
