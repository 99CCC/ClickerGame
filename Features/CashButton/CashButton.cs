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
		GD.Print("ClickAnimation Method Called");
		var sprite = GameManager.Instance._cashButton;

		//0,15 -> 0.075

		_tween.TweenProperty(sprite, "scale", new Vector2(0.95F, 0.95F), 0.075f);
		_tween.TweenProperty(sprite, "scale", Vector2.One, 0.075f);

		GD.Print(sprite.Position.X, sprite.Position.Y);

        //_tween.TweenProperty(sprite, "scale", new Vector2(sprite.Position.X - (sprite.Position.X / 2), sprite.Position.X - (sprite.Position.Y / 2)), 0.5f);

        //_tween.TweenCallback(Callable.From(GetNode("/root/Main/CashButton/Area2D/Sprite2D").QueueFree));

        //tween.TweenProperty(GetNode("Sprite"), "scale", Vector2.Zero, 1.0f);
    }

}

/*
 * Sprite.size = scale_sprite_to_size(Sprite, Vector2(16, 16))

func scale_sprite_to_size(sprite: Sprite2D, new_size: Vector2) -> Vector2:
	if sprite.texture != null:
		return new_size / sprite.texture.get_size()
	return Vector2(1, 1)
*/