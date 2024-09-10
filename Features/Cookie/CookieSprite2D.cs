using Godot;
using System;

public partial class CookieSprite2D : Sprite2D
{
	public Sprite2D _cookie;
	public Label _label;
	// Called when the node enters the scene tree for the first time.
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
                    GD.Print("Cookie clicked");
					//GameManager.Instance.AddClicks();
					GameManager.Instance._counterContainer.AddCookie();
                }
				
			}
		}

	}
}
